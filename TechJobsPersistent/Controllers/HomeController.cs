using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }

        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            // create an instance of the AddJobViewModel and pass it to the view
            // When we creat this instance of AddJobViewModel, this is when we can 
            // get a list of all the employers from the database and pass it into
            // the AddJobViewModel instance!
            // We need to also get a list of all the skills from the database and pass that to the
            // instance of AddJobViewModel just like we did with employers
            // Therefore, the AddJob view will be able to display all of the Employers AND all of the Skills
            return View();
        }

        public IActionResult ProcessAddJobForm(AddJobViewModel viewModel, string[] selectedSkills)
        {
            

            // selected skills is an array of all of the IDs of the skills that were checked in the form
            // when it was submitted
            // i.e. if we selected 3 skills that have the IDs 1,2, and 3,
            // then selectedSkills would look like ---> ["1", "2", "3"];

            // Therefore, we would need to pair up our Job that we are saving to the database with
            // each skill in the selectedSkills array, ie skills 1, 2, and 3

            // we need to create a loop to go through each ID in the selectedSkills array
            foreach (string skillId in selectedSkills)
            {
                // Inside this loop, we need to create a new JobSkill object
                // We are going to create a new JobSkill for each skillId in selectedSkills
                // We do this so that we can create a new job/skill pairing in JobSkills table
                // in our database
                JobSkill newJobSkill = new JobSkill
                {
                    // set the JobId and the SkillId of this new JobSkill
                    // Based on part 2, you would have already created a new Job object and given it an EmployerId and a Name
                    // This is the job object we will referencing to create each new instance of JobSkill

                    // You may notice that when you set the SkillId of the JobSkill in here that you may get
                    // a type error because SkillId is of type int, but each item in selectedSkills
                    // is a string!
                    // To be able to properly set SkillId, you need to parse each skillId into an integer 
                    // each time we create a new JobSkill
                };
                // once we've done this, we can save this JobSkill into the database
                // and that will store the relationship between the skill and the job
                // how do typically go about saving data into database? and what table/DbSet 
                // should add each new JobSkill into?
            }
            return View();
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
