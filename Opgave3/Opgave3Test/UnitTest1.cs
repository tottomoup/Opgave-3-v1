namespace Opgave3Test;

using System.Diagnostics;
using System.Reflection;

// dotnet test --logger "console;verbosity=normal"

[TestClass]
public class UnitTest1
{
    private static int _correctTests = 0;
    private Type DDSType;
    private Type CitizenType;
    private Type ProposalType;
    private Type VoteType;

    public TestContext TestContext { get; set; }

    private static TestContext _testContext;

    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        _correctTests = 0;
        _testContext = context;
        Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
    }

    [TestInitialize]
    public void TestInitialize()
    {
        DDSType = Type.GetType("Opgave3.DirectDemocracySystem, Opgave3");
        CitizenType = Type.GetType("Opgave3.Citizen, Opgave3");
        ProposalType = Type.GetType("Opgave3.Proposal, Opgave3");
        VoteType = Type.GetType("Opgave3.Vote, Opgave3");
    }

    [TestMethod]
    public void TestClasses()
    {
        Assert.IsNotNull(DDSType);
        _correctTests++;
        Assert.IsNotNull(CitizenType);
        _correctTests++;
        Assert.IsNotNull(ProposalType);
        _correctTests++;
        Assert.IsNotNull(VoteType);
        _correctTests++;
    }

    [TestMethod]
    public void TestDDS()
    {
        // Make sure the class has the expected fields
        FieldInfo[] fields = DDSType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.IsTrue(fields.Length >= 2);
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_citizens"));
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_proposals"));
        _correctTests++;


        // Make sure the class has the expected constructor
        ConstructorInfo[] constructors = DDSType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        Assert.IsTrue(constructors.Length >= 1);

        // Make sure the class has the expected methods
        MethodInfo[] methods = DDSType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        Assert.IsTrue(methods.Length >= 5);
        _correctTests++;
        Assert.IsTrue(methods.Any(m => m.Name == "RegisterCitizen"));
        _correctTests++;
        Assert.IsTrue(methods.Any(m => m.Name == "RemoveCitizen"));
        _correctTests++;
        Assert.IsTrue(methods.Any(m => m.Name == "AuthenticateCitizen"));
        _correctTests++;
        Assert.IsTrue(methods.Any(m => m.Name == "SubmitProposal"));
        _correctTests++;
        Assert.IsTrue(methods.Any(m => m.Name == "VoteOnProposal"));
        _correctTests++;
    }

    [TestMethod]
    public void TestCitizen()
    {
        FieldInfo[] fields = CitizenType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.IsTrue(fields.Length >= 5);
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_name"));
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_age"));
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_address"));
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_MitID"));
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_system"));
        _correctTests++;

        ConstructorInfo[] constructors = CitizenType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        Assert.IsTrue(constructors.Length >= 1);
        _correctTests++;

        MethodInfo[] methods = CitizenType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        Assert.IsTrue(methods.Length >= 2);
        _correctTests++;
        Assert.IsTrue(methods.Any(m => m.Name == "Register"));
        _correctTests++;
        Assert.IsTrue(methods.Any(m => m.Name == "CastVote"));
        _correctTests++;
    }

    [TestMethod]
    public void TestProposal()
    {
        FieldInfo[] fields = ProposalType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.IsTrue(fields.Length >= 5);
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_title"));
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_description"));
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_proposer"));
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_votes"));
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_requiredVotes"));
        _correctTests++;

        ConstructorInfo[] constructors = ProposalType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        Assert.IsTrue(constructors.Length >= 1);
        _correctTests++;

        MethodInfo[] methods = ProposalType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        Assert.IsTrue(methods.Length >= 2);
        _correctTests++;
        Assert.IsTrue(methods.Any(m => m.Name == "AddVote"));
        _correctTests++;
        Assert.IsTrue(methods.Any(m => m.Name == "IsPassed"));
        _correctTests++;
    }

    [TestMethod]
    public void TestVote()
    {
        FieldInfo[] fields = VoteType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.IsTrue(fields.Length >= 3);
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_proposal"));
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_citizen"));
        _correctTests++;
        Assert.IsTrue(fields.Any(f => f.Name == "_choice"));
        _correctTests++;


        ConstructorInfo[] constructors = VoteType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        Assert.IsTrue(constructors.Length >= 1);
        _correctTests++;

        MethodInfo[] methods = VoteType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        Assert.IsTrue(methods.Length >= 3);
        _correctTests++;
        Assert.IsTrue(methods.Any(m => m.Name == "GetChoice"));
        _correctTests++;
        Assert.IsTrue(methods.Any(m => m.Name == "GetCitizen"));
        _correctTests++;
        Assert.IsTrue(methods.Any(m => m.Name == "GetProposal"));
        _correctTests++;
    }


    [TestMethod]
    public void TestAll()
    {
        object ddsystem = Activator.CreateInstance(DDSType);
        object citizen = Activator.CreateInstance(CitizenType, "John Doe", 123, "Kolding", "secret");
        object proposal = Activator.CreateInstance(ProposalType, "title", "description", 1, citizen);
        object vote = Activator.CreateInstance(VoteType, proposal, citizen, true);

        MethodInfo RegisterCitizen = DDSType.GetMethod("RegisterCitizen");
        MethodInfo IsPassed = ProposalType.GetMethod("IsPassed");
        MethodInfo SubmitProposal = DDSType.GetMethod("SubmitProposal");
        MethodInfo VoteOnProposal = DDSType.GetMethod("VoteOnProposal");

        RegisterCitizen.Invoke(ddsystem, new object[] { citizen });
        SubmitProposal.Invoke(ddsystem, new object[] { proposal });
        VoteOnProposal.Invoke(ddsystem, new object[] { vote });
        if ((bool)IsPassed.Invoke(proposal, null))
            _correctTests += 1;
    }

    [ClassCleanup]
    public static void CleaningUp()
    {
        Debug.WriteLine("(" + 43 + ") Total score: " + _correctTests / 43f * 100 + "%");
    }
}