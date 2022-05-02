using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.Lambda.TestUtilities;
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
        private ILambdaContext LambdaContextMock = new TestLambdaContext();
        private DynamoDBEvent? dynamoEventMock;

        [SetUp]
        public void Setup()
        {
            // Set up DynamoDbEvents to test our lambda function with
            dynamoEventMock = new DynamoDBEvent
            {
                Records = new List<DynamoDBEvent.DynamodbStreamRecord>
            {
                new DynamoDBEvent.DynamodbStreamRecord
                {
                    EventID = "1",
                    AwsRegion = "ca-central-1",
                    Dynamodb = new StreamRecord
                    {
                        ApproximateCreationDateTime = DateTime.Now,
                        Keys = new Dictionary<string, AttributeValue> { {"id", new AttributeValue { S = "ID1" } } },
                        NewImage = new Dictionary<string, AttributeValue> { { "field1", new AttributeValue { S = "NewValue" } }, { "field2", new AttributeValue { S = "AnotherNewValue" } } },
                        OldImage = new Dictionary<string, AttributeValue> { { "field1", new AttributeValue { S = "OldValue" } }, { "field2", new AttributeValue { S = "AnotherOldValue" } } },
                        StreamViewType = StreamViewType.NEW_AND_OLD_IMAGES
                    }
                },
                new DynamoDBEvent.DynamodbStreamRecord
                {
                    EventID = "2",
                    AwsRegion = "ca-central-1",
                    Dynamodb = new StreamRecord
                    {
                        ApproximateCreationDateTime = DateTime.Now,
                        Keys = new Dictionary<string, AttributeValue> { {"id", new AttributeValue { S = "ID2" } } },
                        NewImage = new Dictionary<string, AttributeValue> { { "field1", new AttributeValue { S = "NewValue" } }, { "field2", new AttributeValue { S = "AnotherNewValue" } } },
                        OldImage = new Dictionary<string, AttributeValue> { { "field1", new AttributeValue { S = "OldValue" } }, { "field2", new AttributeValue { S = "AnotherOldValue" } } },
                        StreamViewType = StreamViewType.NEW_AND_OLD_IMAGES
                    }
                }
            },
            };
        }

        [Test]
        public void AWSLambdaFunction_LogsDynamoDbID()
        {
            // Arrange
            var TestFunction = new Function();

            // Act
            TestFunction.FunctionHandler(dynamoEventMock, LambdaContextMock);

            // Assert
            var testLogger = LambdaContextMock.Logger as TestLambdaLogger;
            var testData = testLogger?.Buffer.ToString();

            Assert.That(testData, Is.Not.Null);
            Assert.That(testData, Contains.Substring("Entry ID: ID1"));
            Assert.That(testData, Contains.Substring("Entry ID: ID2"));
        }
    }
}
