using System.Collections.Generic;
using ComicMaker.Accounts.Data.Interfaces;
using ComicMaker.Accounts.Handlers.Interfaces;
using ComicMaker.Accounts.Models;
using ComicMaker.Common.Commands;
using ComicMaker.Common.Models;
using ComicMaker.Common.Queries;
using ComicMaker.Common.Validators;
using Optional;

namespace ComicMaker.Accounts.Handlers.Implementations
{
    public class AssetHandler : IAssetHandler
    {
        private readonly IAssetQueryRepository _assetQueryRepository;
        private readonly IAssetRepository _assetRepository;
        private readonly GetListQueryValidator _getListQueryValidator;
        private readonly DeleteByIdCommandValidator _deleteByIdCommandValidator;

        public AssetHandler(IAssetQueryRepository assetQueryRepository, IAssetRepository assetRepository)
        {
            _assetQueryRepository = assetQueryRepository;
            _assetRepository = assetRepository;
            _getListQueryValidator = new GetListQueryValidator();
            _deleteByIdCommandValidator = new DeleteByIdCommandValidator();
        }

        public Option<IEnumerable<Asset>, ErrorResult> GetAllForAccount(GetListQuery query)
        {
            return _getListQueryValidator
                .Validate(query)
                .OnSuccess(errorBuilder => _assetQueryRepository.GetAllForAccount(query));
        }

        public Option<SuccessResult, ErrorResult> Delete(DeleteByIdCommand command)
        {
            return _deleteByIdCommandValidator
                .Validate(command)
                .OnSuccess(errorBuilder =>
                {
                    var option = _assetRepository.GetById(command);
                    option.MatchSome(x => _assetRepository.Delete(x));
                });
        }
    }
}