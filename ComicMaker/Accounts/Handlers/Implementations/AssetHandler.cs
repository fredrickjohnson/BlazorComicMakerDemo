using System.Collections.Generic;
using ComicMaker.Accounts.Data.Interfaces;
using ComicMaker.Accounts.Handlers.Interfaces;
using ComicMaker.Accounts.Models;
using ComicMaker.Common.Models;
using ComicMaker.Common.Queries;
using ComicMaker.Common.Validators;
using Optional;

namespace ComicMaker.Accounts.Handlers.Implementations
{
    public class AssetHandler : IAssetHandler
    {
        private readonly IAssetQueryRepository _assetQueryRepository;
        private readonly GetListQueryValidator _getListQueryValidator;

        public AssetHandler(IAssetQueryRepository assetQueryRepository)
        {
            _assetQueryRepository = assetQueryRepository;
            _getListQueryValidator = new GetListQueryValidator();
        }

        public Option<IEnumerable<Asset>, ErrorResult> GetAllForAccount(GetListQuery query)
        {
            return _getListQueryValidator.Validate(query).OnSuccess(errorBuilder =>
            {
                return _assetQueryRepository.GetAllForAccount(query);
            });
        }
    }
}