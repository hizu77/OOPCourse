namespace Labwork5.Application.Models.Accounts;

public record BankAccount(
    string Invoice,
    string PinCode,
    decimal Balance);