namespace Mankala.Tests;

using Mankala;
using Xunit;

public class MankalaRuleFactoryTests
{
    [Theory]
    [InlineData(6, 4)]
    [InlineData(8, 6)]
    [InlineData(128, 256)]
    public void MakeState_ShouldCreateCorrectNumberOfCups(int cupsAmount, int startingPebbles)
    {
        var factory = new MankalaRuleFactory(cupsAmount, startingPebbles);
        var cups = factory.MakeState();
        Assert.Equal(cupsAmount * 2 + 2, cups.Length);
    }

    [Theory]
    [InlineData(6, 4)]
    [InlineData(8, 6)]
    [InlineData(128, 256)]
    public void MakeState_ShouldInitializeCupsCorrectly(int cupsAmount, int startingPebbles)
    {
        var factory = new MankalaRuleFactory(cupsAmount, startingPebbles);
        var cups = factory.MakeState();
        for (int i = 1; i <= cupsAmount; i++)
        {
            Assert.Equal(startingPebbles, cups[i].Pebbles);
            Assert.Equal(Cup.CupType.Regular, cups[i].Type);
        }
    }

    [Fact]
    public void MakeRuleset_ShouldReturnMankalaRules()
    {
        var factory = new MankalaRuleFactory();
        var ruleset = factory.MakeRuleset();
        Assert.IsType<MankalaRules>(ruleset);
    }

    [Fact]
    public void MakeWinFormsGraphics_ShouldReturnBasicWinFormsGraphics()
    {
        var factory = new MankalaRuleFactory();
        var graphics = factory.MakeWinFormsGraphics();
        Assert.IsType<BasicWinFormsGraphics>(graphics);
    }
}
public class WariRuleFactoryTests
{
    [Theory]
    [InlineData(6, 4)]
    [InlineData(8, 6)]
    public void MakeState_ShouldCreateCorrectNumberOfCups(int cupsAmount, int startingPebbles)
    {
        var factory = new WariRuleFactory(cupsAmount, startingPebbles);
        var cups = factory.MakeState();
        Assert.Equal(cupsAmount * 2 + 2, cups.Length);
    }

    [Theory]
    [InlineData(6, 4)]
    [InlineData(8, 6)]
    public void MakeState_ShouldInitializeCupsCorrectly(int cupsAmount, int startingPebbles)
    {
        var factory = new WariRuleFactory(cupsAmount, startingPebbles);
        var cups = factory.MakeState();
        for (int i = 1; i <= cupsAmount; i++)
        {
            Assert.Equal(startingPebbles, cups[i].Pebbles);
            Assert.Equal(Cup.CupType.Regular, cups[i].Type);
        }
    }

    [Fact]
    public void MakeRuleset_ShouldReturnWariRules()
    {
        var factory = new WariRuleFactory();
        var ruleset = factory.MakeRuleset();
        Assert.IsType<WariRules>(ruleset);
    }

    [Fact]
    public void MakeWinFormsGraphics_ShouldReturnBasicWinFormsGraphics()
    {
        var factory = new WariRuleFactory();
        var graphics = factory.MakeWinFormsGraphics();
        Assert.IsType<BasicWinFormsGraphics>(graphics);
    }
}

public class WankalaRuleFactoryTests
{
    [Theory]
    [InlineData(6, 4)]
    [InlineData(8, 6)]
    public void MakeState_ShouldCreateCorrectNumberOfCups(int cupsAmount, int startingPebbles)
    {
        var factory = new WankalaRuleFactory(cupsAmount, startingPebbles);
        var cups = factory.MakeState();
        Assert.Equal(cupsAmount * 2 + 2, cups.Length);
    }

    [Theory]
    [InlineData(6, 4)]
    [InlineData(8, 6)]
    public void MakeState_ShouldInitializeCupsCorrectly(int cupsAmount, int startingPebbles)
    {
        var factory = new WankalaRuleFactory(cupsAmount, startingPebbles);
        var cups = factory.MakeState();
        for (int i = 1; i <= cupsAmount; i++)
        {
            Assert.Equal(startingPebbles, cups[i].Pebbles);
            Assert.Equal(Cup.CupType.Regular, cups[i].Type);
        }
    }

    [Fact]
    public void MakeRuleset_ShouldReturnWankalaRules()
    {
        var factory = new WankalaRuleFactory();
        var ruleset = factory.MakeRuleset();
        Assert.IsType<WankalaRules>(ruleset);
    }

    [Fact]
    public void MakeWinFormsGraphics_ShouldReturnBasicWinFormsGraphics()
    {
        var factory = new WankalaRuleFactory();
        var graphics = factory.MakeWinFormsGraphics();
        Assert.IsType<BasicWinFormsGraphics>(graphics);
    }
}

