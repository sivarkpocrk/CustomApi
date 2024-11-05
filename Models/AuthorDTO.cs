using System;
using AutoMapper;
using CustomApi.Models;
using System.ComponentModel.DataAnnotations;

namespace CustomApi.Models
{
public class AuthorDTO
{
    public int Id { get; set; }
        /// <summary>
        /// Gets or sets the first name of the author. This field is required.
        /// </summary>
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the author. This field is required.
        /// </summary>
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}

}

