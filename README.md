# MagentoTests

This automation project has been developed using C#, Selenium WebDriver and SpecFlow (BDD).

The test case is detailed in the BizCover assessment document.

The IDE of choice is JetBrains Rider.  

_To run the automated test scenario:_
1) Checkout the project from Github
2) Import the project into Rider
3) Download the required plugins - SpecFlow and Selenium WebDriver through Rider NuGet
4) There is one feature file called "Checkout.feature". Use the IDE option to run the tests of the feature.
You can see the test output directly in the IDE.

The SpecFlow framework provides LivingDoc plugin to generate HTML report of the test output. To install
the LivingDoc CLI, go to the terminal in IDE and type in the following command:

<code> dotnet tool update --global SpecFlow.Plus.LivingDoc.CLI </code>

After successful installation of CLI, go to the bin/Debug/net6.0 folder. In my machine this is the path to go:

<code>/Users/anandhih/RiderProjects/MagentoTests/MagentoTestCases/bin/Debug/net6.0</code>

We require two files from this folder to generate the HTML report. They are: <code>MagentoTestCases.dll</code> and 
<code>TestExecution.json</code>
These files are generated after building the project and running the tests.

Now, run the following command:
<code>livingdoc test-assembly MagentoTestCases.dll -t TestExecution.json</code>

This will create the test output HTML file, named as "LivingDoc.html" in the current folder.

### **Please refer to the screenshots in the "AutomatedTestOutputs" folder.**


