using System.Collections.Generic;
using ComicMaker.Accounts.Commands;
using ComicMaker.Accounts.Data.Interfaces;
using ComicMaker.Accounts.Handlers.Interfaces;
using ComicMaker.Accounts.Mappers;
using ComicMaker.Accounts.Validators;
using ComicMaker.Common.Commands;
using ComicMaker.Common.Models;
using ComicMaker.Common.Queries;
using ComicMaker.Common.Validators;
using ComicMaker.Projects.Models;
using Optional;

namespace ComicMaker.Accounts.Handlers.Implementations
{
    public class CharacterHandler : ICharacterHandler
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly ICharacterQueryRepository _characterQueryRepository;
        private readonly CharacterMapper _mapper;
        private readonly CreateCharacterCommandValidator _createCharacterCommandValidator;
        private readonly UpdateCharacterCommandValidator _updateCharacterCommandValidator;
        private readonly DeleteByIdCommandValidator _deleteByIdCommandValidator;
        private readonly GetListQueryValidator _getListQueryValidator;
        

        public CharacterHandler(ICharacterRepository characterRepository, ICharacterQueryRepository characterQueryRepository)
        {
            _characterRepository = characterRepository;
            _characterQueryRepository = characterQueryRepository;
            _mapper = new CharacterMapper();
            _createCharacterCommandValidator = new CreateCharacterCommandValidator();
            _updateCharacterCommandValidator = new UpdateCharacterCommandValidator();
            _deleteByIdCommandValidator = new DeleteByIdCommandValidator();
            _getListQueryValidator = new GetListQueryValidator();
        }
        
        public Option<IEnumerable<Character>, ErrorResult> GetAllForAccount(GetListQuery query)
        {
            return _getListQueryValidator.Validate(query).OnSuccess(errorBuilder =>
                {
                    return _characterQueryRepository.GetAllForAccount(query);
                });
        }

        public Option<SuccessResult, ErrorResult> Create(CreateCharacterCommand command)
        {
            return _createCharacterCommandValidator.Validate(command).OnSuccess(errorBuilder =>
            {
                _characterRepository.Insert(_mapper.Map(command));
            });
        }

        public Option<SuccessResult, ErrorResult> Update(UpdateCharacterCommand command)
        {
            return _updateCharacterCommandValidator.Validate(command).OnSuccess(errorBuilder =>
            {
                var option = _characterRepository.GetById(command);
                option.MatchSome(x => _characterRepository.Update(_mapper.Map(command,x)));
                option.MatchNone(errorBuilder.AddRecordNotFound);
            });
        }

        public Option<SuccessResult, ErrorResult> Delete(DeleteByIdCommand command)
        {
            return _deleteByIdCommandValidator.Validate(command).OnSuccess(errorBuilder =>
            {
                var option = _characterRepository.GetById(command);
                option.MatchSome(x => _characterRepository.Delete(x));
                option.MatchNone(errorBuilder.AddRecordNotFound);
            });
        }
    }
}