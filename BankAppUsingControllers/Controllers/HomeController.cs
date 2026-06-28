using BankAppUsingControllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAppUsingControllers.Controllers
{
    public class HomeController : Controller
    {
        AccountDetails accountDetails = new AccountDetails()
        {
            accountNumber = 1001,
            accountHolderName = "John Doe",
            currentBalance = 1000
        };
        [Route("/")]    
        public IActionResult Index()
        {
            return Ok("Welcome to the Bank App!");

        }
        [HttpGet]
        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            Response.StatusCode = 200;
            return Json(accountDetails);
        }
        [HttpGet]
        [Route("/account-statement")]
        public IActionResult AccountStatement()
        {
            Response.StatusCode = 200;
           return PhysicalFile(@"D:\\maa schedule\schdule.pdf", "application/pdf");
        }
        [HttpGet]
        [Route("get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance()
        {
           
            if (!Request.RouteValues.ContainsKey("accountNumber") || Request.RouteValues["accountNumber"] == null)
            {
                
                
                    return NotFound("Account number should be supplied");
           

            }
            int? myaccountNumber = Convert.ToInt32(Request.RouteValues["accountNumber"]);
            if (myaccountNumber != accountDetails.accountNumber)
            {
                return BadRequest("Account Number should be 1001");
            }
            
                
            return Ok($"Current Balance is {accountDetails.currentBalance}");
           

        }


    }
}
