using System;
using System.Collections.Generic;
using ComicMaker.Common.Commands;
using ComicMaker.Common.Models;
using ComicMaker.Common.Queries;
using ComicMaker.Common.Validators;
using ComicMaker.Projects.Commands;
using ComicMaker.Projects.Data.Interfaces;
using ComicMaker.Projects.Handlers.Interfaces;
using ComicMaker.Projects.Mappers;
using ComicMaker.Projects.Models;
using ComicMaker.Projects.Services.Interfaces;
using ComicMaker.Projects.Validators;
using Optional;

namespace ComicMaker.Projects.Handlers.Implementations
{
    public class SceneHandler : ISceneHandler
    {
        private readonly ISceneRepository _sceneRepository;
        private readonly ISceneQueryRepository _sceneQueryRepository;
        private readonly SceneMapper _mapper;
        private readonly CreateSceneCommandValidator _createSceneCommandValidator;
        private readonly UpdateSceneCommandValidator _updateSceneCommandValidator;
        private readonly DeleteByIdCommandValidator _deleteByIdCommandValidator;
        private readonly GetListByParentIdQueryValidator _getListByParentIdQueryValidator;

        public SceneHandler(ISceneRepository sceneRepository, IProjectPartitionKeyGenerator partitionKeyGenerator, ISceneQueryRepository sceneQueryRepository)
        {
            _sceneRepository = sceneRepository;
            _sceneQueryRepository = sceneQueryRepository;
            _mapper = new SceneMapper(partitionKeyGenerator);
            _createSceneCommandValidator = new CreateSceneCommandValidator();
            _updateSceneCommandValidator = new UpdateSceneCommandValidator();
            _deleteByIdCommandValidator = new DeleteByIdCommandValidator();
            _getListByParentIdQueryValidator = new GetListByParentIdQueryValidator();
        }

        public Option<IEnumerable<Scene>, ErrorResult> GetAllFor(GetListByParentIdQuery query)
        {
            return _getListByParentIdQueryValidator
                .Validate(query)
                .OnSuccess(errorBuilder => _sceneQueryRepository.GetAllForProject(query));
        }

        public Option<SuccessResult, ErrorResult> Create(CreateSceneCommand command)
        {
            return _createSceneCommandValidator
                .Validate(command)
                .OnSuccess(errorBuilder =>
                {
                    _sceneRepository.Insert(_mapper.Map(command));
                });
        }

        public Option<SuccessResult, ErrorResult> Update(UpdateSceneCommand command)
        {
            return _updateSceneCommandValidator
                .Validate(command)
                .OnSuccess(errorBuilder =>
                {
                    var option = _sceneRepository.GetById(command);
                    option.MatchSome(x => _sceneRepository.Update(_mapper.Map(command, x)));
                    option.MatchNone(errorBuilder.AddRecordNotFound);
                });
        }

        public Option<SuccessResult, ErrorResult> Delete(DeleteByIdCommand command)
        {
            return _deleteByIdCommandValidator
                .Validate(command)
                .OnSuccess(errorBuilder =>
                {
                    var option = _sceneRepository.GetById(command);
                    option.MatchSome(x => _sceneRepository.Delete(x));
                    option.MatchNone(errorBuilder.AddRecordNotFound);
                });
        }
    }
}