﻿namespace User.API.InputModels.UserInputModels
{
    public class UpdateUserInputModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string? MiddleName { get; set; }
        public string? Gender { get; set; }
        public bool AcceptTerms { get; set; }
    }
}
