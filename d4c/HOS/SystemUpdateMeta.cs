namespace d4c.HOS;

public class SystemUpdateMeta
{
    public int timestamp { get; set; }
    public IList<SystemUpdateMetas> system_update_metas { get; set; }

    public SystemUpdateMeta()
    {
        system_update_metas = new List<SystemUpdateMetas>();
    }
}

public class SystemUpdateMetas
{
    public string title_id;
    public uint title_version;

    public SystemUpdateMetas(string s, uint versionVersion)
    {
        title_id = s;
        title_version = versionVersion;
    }
}

public class required_system_update_meta
{
    public string contents_delivery_required_title_id;
    public uint contents_delivery_required_title_version;
}