using System;
using ComicMaker.Common.Commands;
using ComicMaker.Common.Models;
using ComicMaker.Common.Validators;
using ComicMaker.Projects.Commands;
using ComicMaker.Projects.Data.Interfaces;
using ComicMaker.Projects.Handlers.Interfaces;
using ComicMaker.Projects.Mappers;
using ComicMaker.Projects.Services.Interfaces;
using ComicMaker.Projects.Validators;
using Optional;

namespace ComicMaker.Projects.Handlers.Implementations
{
    public class ProjectHandler : IProjectHandler
    {
        private readonly IProjectQueryRepository _projectQueryRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ProjectMapper _mapper;

        private readonly CreateProjectCommandValidator _createProjectCommandValidator;
        private readonly UpdateProjectCommandValidator _updateProjectCommandValidator;
        private readonly GetListQueryValidator _getListQueryValidator;
        private readonly GetByIdQueryValidator _getByIdQueryValidator;
        private readonly DeleteByIdCommandValidator _deleteByIdCommandValidator;

        public ProjectHandler(IProjectQueryRepository projectQueryRepository, IProjectRepository projectRepository, IProjectPartitionKeyGenerator partitionKeyGenerator)
        {
            _projectQueryRepository = projectQueryRepository;
            _projectRepository = projectRepository;
            _mapper = new ProjectMapper(partitionKeyGenerator);
            _createProjectCommandValidator = new CreateProjectCommandValidator();
            _updateProjectCommandValidator = new UpdateProjectCommandValidator();
            _getListQueryValidator = new GetListQueryValidator();
            _getByIdQueryValidator = new GetByIdQueryValidator();
            _deleteByIdCommandValidator = new DeleteByIdCommandValidator();
        }

        public Option<SuccessResult, ErrorResult> Create(CreateProjectCommand command)
        {
            return _createProjectCommandValidator
                .Validate(command)
                .OnSuccess(errorBuilder =>
                {
                    _projectRepository.Insert(_mapper.Create(command));
                });
        }

        public Option<SuccessResult, ErrorResult> Update(UpdateProjectCommand command)
        {
            return _updateProjectCommandValidator
                .Validate(command)
                .OnSuccess(errorBuilder =>
                {
                    var option = _projectRepository.GetById(command);
                    option.MatchSome(x =>
                    {
                        _projectRepository.Update(_mapper.Update(command,x));
                    });
                   option.MatchNone(errorBuilder.AddRecordNotFound);
                });
        }

        public Option<SuccessResult, ErrorResult> Delete(DeleteByIdCommand command)
        {
            return _deleteByIdCommandValidator
                .Validate(command)
                .OnSuccess(errorBuilder =>
                {
                    var option = _projectRepository.GetById(command);
                    option.MatchSome(x => _projectRepository.Delete(x));
                });
        }
    }
}