using Cwiczenia10.Contexts;
using Cwiczenia10.Exceptions;
using Cwiczenia10.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia10.Services;

public interface IAccountService
{
    Task<GetAccountResponseModel> GetAccountByIdAsync(int id);
}

public class AccountService(DatabaseContext databaseContext) : IAccountService
{
    public async Task<GetAccountResponseModel> GetAccountByIdAsync(int id)
    {
        var fkRole = await databaseContext.Accounts
            .Where(e => e.PkAccount == id)
            .Select(e => e.FkRole).FirstOrDefaultAsync();

        var roleName = await databaseContext.Roles
            .Where(e => e.PkRole == fkRole)
            .Select(e => e.Name).FirstOrDefaultAsync();
        
        var acc = await databaseContext.Accounts
            .Where(e => e.PkAccount == id)
            .Select(e => new GetAccountResponseModel
            {
                firstName = e.FirstName,
                lastName = e.LastName,
                email = e.Email,
                phone = e.Phone,
                role = roleName
            }).FirstOrDefaultAsync();

        if (acc is null)
        {
            throw new NotFoundException($"Account with id:{id} does not exist!");
        }

        return acc;
    }
}