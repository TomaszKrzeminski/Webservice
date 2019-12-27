using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Calculator;
using static Calculator.CalculatorSoapClient;
using WebServiceApp.Models;

namespace WebServiceApp.Controllers
{
    public class CalculatorSoapController : Controller
    {

        public IActionResult Calculator()
        {
            CalculatorData data = new CalculatorData() {A=10,B=5,Operation="Add" };
            return View("CalculatorView",data);
        }





        public async Task<IActionResult> Action(CalculatorData data)
        {

            var calc = new CalculatorSoapClient(EndpointConfiguration.CalculatorSoap);



            switch (data.Operation)
            {
                case "Add":
                   data.Result = await calc.AddAsync(data.A, data.B);
                    break;
                case "Divide":
                    data.Result = await calc.DivideAsync(data.A, data.B);
                    break;
                case "Subtract":
                    data.Result = await calc.SubtractAsync(data.A, data.B);
                    break;
                case "Multiply":
                    data.Result = await calc.MultiplyAsync(data.A, data.B);
                    break;
                default:
                   
                    break;
            }






            return View("CalculatorResult", data);
        }




        public async Task<IActionResult> Add()
        {

            var calc = new CalculatorSoapClient(EndpointConfiguration.CalculatorSoap);

            int add =await calc.AddAsync(1, 2);

            return View(add);
        }
        public async Task<IActionResult> Divide()
        {
            var calc = new CalculatorSoapClient(EndpointConfiguration.CalculatorSoap);

            int add = await calc.DivideAsync(4, 2);

            return View(add);
        }
        public async Task<IActionResult> Subtract()
        {
            var calc = new CalculatorSoapClient(EndpointConfiguration.CalculatorSoap);

            int add = await calc.SubtractAsync(22, 2);

            return View(add);
        }
        public async Task<IActionResult> Multiply()
        {
            var calc = new CalculatorSoapClient(EndpointConfiguration.CalculatorSoap);

            int add = await calc.MultiplyAsync(3, 4);

            return View(add);
        }
    }
}