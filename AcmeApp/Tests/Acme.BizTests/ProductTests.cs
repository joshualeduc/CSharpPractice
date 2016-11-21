﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        //These tests show the 3 ways we can initialize objects in C#
        [TestMethod()]
        //Initializing objects by setting properties is best when
        //    - When populating from database values
        //    - When modifying properties
        public void SayHelloTest()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.Description = "15-inch steel blade hand saw";
            currentProduct.ProductVendor.CompanyName = "ABC Corp";
            var expected = "Hello Saw (1): 15-inch steel blade hand saw Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        //Initializing objects by using a parameterized constructor is best when
        //    - When setting the basic set of properties
        public void SayHello_ParameterizedConstructor()
        {
            //Arrange
            var currentProduct = new Product(1, "Saw",
                                 "15-inch steel blade hand saw");

            var expected = "Hello Saw (1): 15-inch steel blade hand saw Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        //Initializing objects by using an object initializer is best when
        //    - When readability is important
        //    - When initializing a subset or superset of properties
        public void SayHello_ObjectInitializer()
        {
            //Arrange
            var currentProduct = new Product
            {
                ProductId = 1,
                ProductName = "Saw",
                Description = "15-inch steel blade hand saw"
            };

            var expected = "Hello Saw (1): 15-inch steel blade hand saw Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_Null()
        {
            //Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName; //C# 6 null checking syntax

            string expected = null;

            //Act
            var actual = companyName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertMetersToInchesTest()
        {
            // Arrange
            var expected = 78.74;

            // Act
            var actual = 2 * Product.InchesPerMeter;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTest_Default()
        {
            // Arrange
            var currentProduct = new Product();
            var expected = .96m;

            // Act
            var actual = currentProduct.MinimumPrice;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTest_Bulk()
        {
            // Arrange
            var currentProduct = new Product(1, "Bulk Tools", "");
            var expected = 9.99m;

            // Act
            var actual = currentProduct.MinimumPrice;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_Format()
        {
            // Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = " Steel Hammer ";
            var expected = "Steel Hammer";

            // Act
            var actual = currentProduct.ProductName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductName_TooShort()
        {
            // Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "aw";
            string expected = null;
            string expectedMessage = "Product Name must be at least 3 characters";

            // Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void ProductName_TooLong()
        {
            // Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Steel Bladed hand Saw";
            string expected = null;
            string expectedMessage = "Product Name cannot be more than 20 characters";

            // Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void ProductName_JustRight()
        {
            // Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            string expected = "Saw";
            string expectedMessage = null;

            // Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void Cateogry_DefaultValue()
        {
            // Arrange
            var currentProduct = new Product();
            var expected = "Tools";

            // Act
            var actual = currentProduct.Category;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Cateogry_NewValue()
        {
            // Arrange
            var currentProduct = new Product();
            currentProduct.Category = "Garden";
            var expected = "Garden";

            // Act
            var actual = currentProduct.Category;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Sequence_DefaultValue()
        {
            // Arrange
            var currentProduct = new Product();
            var expected = 1;

            // Act
            var actual = currentProduct.SequenceNumber;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Sequence_NewValue()
        {
            // Arrange
            var currentProduct = new Product();
            currentProduct.SequenceNumber = 5;
            var expected = 5;

            // Act
            var actual = currentProduct.SequenceNumber;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ProductCode_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = "Tools-1";

            //Act
            var actual = currentProduct.ProductCode;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CalculateSuggestedPriceTest()
        {
            //Arrange
            var currentProduct = new Product(1, "Saw", "");
            currentProduct.Cost = 50m;
            var expected = 55m;

            //Act
            var actual = currentProduct.CalculateSuggestedPrice(10m);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}