namespace ConsoleWebServer.Tests
{
    using ConsoleWebServer.Framework;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ActionDecriptorTest
    {
        private const char UriSeparator = '/';
        private const string DefaultControllerName = "Home";
        private const string DefaultActionName = "Index";
        private const string DefaultParameter = "Param";
        private const string StringFormat = "/{0}/{1}/{2}";

        [TestMethod]
        public void Test_ActiontDecriptorConstructorWithNullSetsEmptyUriANdNotThrowException()
        {
            Assert.IsTrue(true, "Exception was thrown");
        } 

        [TestMethod]
        public void Test_ActiontDecriptorConstructorWithNull()
        {
            var actionDecriptor = new ActionDescriptor(null);
            bool isControllerNameCorect = actionDecriptor.ControllerName == DefaultControllerName;
            bool isActionNameCorect = actionDecriptor.ActionName == DefaultActionName;
            bool isParameterNameCorect = actionDecriptor.Parameter == DefaultParameter;

            Assert.IsTrue(isControllerNameCorect && isActionNameCorect && isParameterNameCorect, "Sets all properties correct");
        }

        [TestMethod]
        public void Test_ActiontDecriptorConstructorWithNullToStringReturns()
        {
            var actionDecriptor = new ActionDescriptor(null);
            bool isControllerNameCorect = actionDecriptor.ControllerName == DefaultControllerName;
            bool isActionNameCorect = actionDecriptor.ActionName == DefaultActionName;
            bool isParameterNameCorect = actionDecriptor.Parameter == DefaultParameter;

            var toStringReturnValue = actionDecriptor.ToString();
            var expected = string.Format("/{0}/{1}/{2}", actionDecriptor.ControllerName, actionDecriptor.ActionName, actionDecriptor.Parameter);

            Assert.IsTrue(toStringReturnValue == expected, "ToString() should return correct value!");
        }

        [TestMethod]
        public void Test_ActiontDecriptorConstructorWithEmptyStringToStringReturnsCorrect()
        {
            var actionDecriptor = new ActionDescriptor(string.Empty);
            bool isControllerNameCorect = actionDecriptor.ControllerName == DefaultControllerName;
            bool isActionNameCorect = actionDecriptor.ActionName == DefaultActionName;
            bool isParameterNameCorect = actionDecriptor.Parameter == DefaultParameter;

            var toStringReturnValue = actionDecriptor.ToString();
            var expected = string.Format("/{0}/{1}/{2}", actionDecriptor.ControllerName, actionDecriptor.ActionName, actionDecriptor.Parameter);

            Assert.IsTrue(toStringReturnValue == expected, "ToString() should return correct value when param is string.Empty");
        }

        [TestMethod]
        public void Test_ActiontDecriptorConstructorToStringSetsCorrectProperties()
        {
            var actionDecriptor = new ActionDescriptor("ControllerName/ActionName/ParameterName");
            bool isControllerNameCorect = actionDecriptor.ControllerName == "ControllerName";
            bool isActionNameCorect = actionDecriptor.ActionName == "ActionName";
            bool isParameterNameCorect = actionDecriptor.Parameter == "ParameterName";

            var toStringReturnValue = actionDecriptor.ToString();
            var expected = string.Format("/{0}/{1}/{2}", actionDecriptor.ControllerName, actionDecriptor.ActionName, actionDecriptor.Parameter);

            Assert.IsTrue(isControllerNameCorect && isActionNameCorect && isParameterNameCorect, "All properties must set correct!");
        }

        [TestMethod]
        public void Test_ActiontDecriptorConstructorWithTwoParamsToStringSetsCorrectProperties()
        {
            var actionDecriptor = new ActionDescriptor("ControllerName/ActionName/");
            bool isControllerNameCorect = actionDecriptor.ControllerName == "ControllerName";
            bool isActionNameCorect = actionDecriptor.ActionName == "ActionName";
            bool isParameterNameCorect = actionDecriptor.Parameter == DefaultParameter;

            var toStringReturnValue = actionDecriptor.ToString();
            var expected = string.Format("/{0}/{1}/{2}", actionDecriptor.ControllerName, actionDecriptor.ActionName, actionDecriptor.Parameter);

            Assert.IsTrue(isControllerNameCorect && isActionNameCorect && isParameterNameCorect, "All properties must set correct!");
        }

        [TestMethod]
        public void Test_ActiontDecriptorConstructorWithOneParamsToStringSetsCorrectProperties()
        {
            var actionDecriptor = new ActionDescriptor("/ControllerName/");
            bool isControllerNameCorect = actionDecriptor.ControllerName == "ControllerName";
            bool isActionNameCorect = actionDecriptor.ActionName == DefaultActionName;
            bool isParameterNameCorect = actionDecriptor.Parameter == DefaultParameter;

            var toStringReturnValue = actionDecriptor.ToString();
            var expected = string.Format("/{0}/{1}/{2}", actionDecriptor.ControllerName, actionDecriptor.ActionName, actionDecriptor.Parameter);

            Assert.IsTrue(isControllerNameCorect && isActionNameCorect && isParameterNameCorect, "All properties must set correct!");
        }
    }
}
