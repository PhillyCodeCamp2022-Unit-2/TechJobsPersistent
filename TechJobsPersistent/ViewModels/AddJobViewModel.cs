using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        // [Required]
        public string Name { get; set; }
        // [Required]
        public int EmployerId { get; set; }
        // list of all employers as SelectListItem
        public List<SelectListItem> Employers { get; set; }
        // How do we get all the employers from the database and use them
        // to populate a select list of options in our AddJob form?
        // This Employers SelectListItem list is a really nice way to display data
        // in a select option list in a form, but it won't automatically get all of the
        // employers from the database on its own. We have to provide that information
        // when we create an instance of the AddJobViewModel!

        // This property will contain a list of all skills from the database
        // Since we aren't needing to use SelectListItem, we don't need go through the process
        // of translating Skills into SelectListItems in the constructor like we did for Employers
        public List<Skill> Skills { get; set; }

        public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        {
            // employers is a list of all of the actual Employer objects from the database
            // So the job of this constructor is to translate all of the Employer objects
            // from the databse into SelectListItem objects so we can then render them
            // in the AddJob form

            // By the time we are done looping through the list of all of the employers from the database,
            // we should be left with a SelectListItem list that contains SelectListItems that each represent
            // an employer object from the database

            // set our Skills property equal to the skills list parameter
            Skills = skills;
        }

        public AddJobViewModel() { }
    }
}
