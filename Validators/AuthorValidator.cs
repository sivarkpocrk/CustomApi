
using FluentValidation;
using CustomApi.Models;
using System;
public class AuthorValidator : AbstractValidator<AuthorDTO>
{
    public AuthorValidator()
    {
        RuleFor(a => a.FirstName).NotEmpty().WithMessage("First Name is required.");
        RuleFor(a => a.LastName).NotEmpty().WithMessage("Last Name is required.");
        RuleFor(a => a.Email).EmailAddress().WithMessage("A valid email is required.");
        RuleFor(a => a.DateOfBirth).LessThan(DateTime.Now).WithMessage("Date of Birth must be in the past.");
    }
}
