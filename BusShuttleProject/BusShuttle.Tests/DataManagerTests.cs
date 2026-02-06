namespace BusShuttle.Tests;

using BusShuttle;

public class DataManagerTests
{
    DataManager dataManager;

    public DataManagerTests() {
        File.WriteAllText("stops.txt","One"+Environment.NewLine+"Two"+Environment.NewLine+"Three"+Environment.NewLine+"Four"+Environment.NewLine+"Five");
        dataManager = new DataManager();
    }

    [Fact]
    public void Test_AddStop()
    {
        Assert.Equal(5,dataManager.Stops.Count);
        dataManager.AddStop(new Stop("new stop"));
        Assert.Equal(6,dataManager.Stops.Count);
    }

    [Fact]
    public void Test_Drivers_File_Load_And_Modify()
    {
        // ensure drivers file is controlled for test
        File.WriteAllText("drivers.txt","Alice"+Environment.NewLine+"Bob");
        var dm = new DataManager();
        Assert.Equal(2, dm.Drivers.Count);
        dm.AddDriver(new Driver("Charlie"));
        Assert.Equal(3, dm.Drivers.Count);
        dm.RemoveDriver(dm.Drivers.First(d => d.Name=="Alice"));
        Assert.Equal(2, dm.Drivers.Count);
    }

}