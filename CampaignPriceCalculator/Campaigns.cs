
public class ComboCampaign
{
    public long[] Products { get; set; } = new long[0];
    public long[] Items { get; set; } = new long[0];
    public decimal CampaignPrice { get; set; }
}

public class VolumeCampaign
{
    public VolumePrice[] VolumePrices = new VolumePrice[0];
}

public class VolumePrice
{
    public long EAN { get; set; }
    public decimal Price { get; set; }
    public int MinimumItems { get; set; }
}