using IRF_Project_Work.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Project_Work.Test
{
    public class ExchangeControllerTestFixture
    {
        [Test,
            TestCase(-1.0,false),
            TestCase(25,true),
            TestCase(1001,false)

        ]
        public void TestValidateValue(decimal value, bool expectedResult)
        {
            //arrange
            var exchangeController = new ExchangeController();
            //act
            var actualResult = exchangeController.ValidateValue(value);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test,
            TestCase("USD",true),
            TestCase("AYAY",false),
            TestCase("",false)
        ]
        public void TestValidateFavorite(string value, bool expectedResult)
        {
            //arrange
            var exchangeController = new ExchangeController();
            //act
            var actualResult = exchangeController.ValidateFavorite(value);
            //assert
            Assert.AreEqual(expectedResult, actualResult);
        }



    }
}
