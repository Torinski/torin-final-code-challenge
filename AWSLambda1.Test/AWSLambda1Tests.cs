using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSLambda1.Test
{
    public class AWSLambda1Tests
    {
        private Mock<ILambdaContext> _context = new Mock<ILambdaContext>();
        private ILambdaContext LambdaContextMock;
        private Mock<DynamoDBEvent> _dbevent = new Mock<DynamoDBEvent>();
        private DynamoDBEvent dynamoEventMock;

        [SetUp]
        public void Setup()
        {
            LambdaContextMock = _context.Object;
            dynamoEventMock = _dbevent.Object;
        }

        [Test]
        public void AWSLambdaFunction_LogsDynamoDbID()
        {
            // Arrange
            var TestFunction = new Function();

            // Act
            TestFunction.FunctionHandler(dynamoEventMock, LambdaContextMock);
            var TestData = LambdaContextMock.Logger.ToString();
            Console.WriteLine(TestData);

            // Assert
            Assert.That(TestData, Is.Not.Null);
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
