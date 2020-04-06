using ComicMaker.Accounts.Commands;
using ComicMaker.Accounts.Data.Interfaces;
using ComicMaker.Accounts.Handlers.Interfaces;
using ComicMaker.Accounts.Mappers;
using ComicMaker.Accounts.Validators;
using ComicMaker.Common.Models;
using ComicMaker.Common.Validators;
using Optional;

namespace ComicMaker.Accounts.Handlers.Implementations
{
    public class AccountHandler : IAccountHandler
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly AccountMapper _mapper;
        private readonly CreateAccountCommandValidator _createAccountCommandValidator;
        private readonly AddUserToAccountCommandValidator _addUserToAccountCommandValidator;
        private readonly RemoveUserFromAccountCommandValidator _removeUserFromAccountCommandValidator;

        public AccountHandler(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _mapper = new AccountMapper();
            _createAccountCommandValidator = new CreateAccountCommandValidator();
            _addUserToAccountCommandValidator = new AddUserToAccountCommandValidator();
            _removeUserFromAccountCommandValidator = new RemoveUserFromAccountCommandValidator();
        }

        public Option<SuccessResult, ErrorResult> Create(CreateAccountCommand command)
        {
            return _createAccountCommandValidator.Validate(command).OnSuccess(errorBuilder =>
            {
                _accountRepository.Insert(_mapper.Map(command));
            });
        }

        public Option<SuccessResult, ErrorResult> AddUser(AddUserToAccountCommand command)
        {
            return _addUserToAccountCommandValidator.Validate(command).OnSuccess(errorBuilder =>
            {
               
            });
        }

        public Option<SuccessResult, ErrorResult> RemoveUser(RemoveUserFromAccountCommand command)
        {
            return _removeUserFromAccountCommandValidator.Validate(command).OnSuccess(errorBuilder =>
            {

            });
        }
    }
}
