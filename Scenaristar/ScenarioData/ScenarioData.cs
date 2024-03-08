using Hack.io.BCSV;
using static Scenaristar.ScenarioData;

namespace Scenaristar;

public class ScenarioData : List<Scenario>
{
    public const uint HASH_SCENARIOID = 0xED08B591; //ScenarioID
    public const uint HASH_SCENARIONAME = 0xCDB16E5B; //Scenario Name
    public const uint HASH_POWERSTARID = 0x7DAF4852; //PowerStarID
    public const uint HASH_APPEARENCE = 0x5A59AAD5; //AppearPowerStarObj
    public const uint HASH_POWERSTARTYPE = 0xCF03D8B1; //PowerStarType
    public const uint HASH_COMET = 0x03E441D0; //Comet
    public const uint HASH_COMETLIMITTIMER = 0x9009023A; //CometLimitTimer
    public const uint HASH_LUIGIMODETIMER = 0x500B84C0; //CometLimitTimer
    public const uint HASH_ISHIDDEN = 0xE375F394; //IsHidden
    public const uint HASH_ERRORCHECK = 0xD6C80400; //ErrorCheck - Never used

    public const uint HASH_POWERSTARCOLOR = 0x108314CC; //PowerStarColor. This is only included if it was present in the original BCSV


    public const uint HASH_ZONENAME = 0x3666C077;

    /// <summary>
    /// Array of Hashes that every Scenario BCSV will contain
    /// </summary>
    static readonly uint[] FixedHashesSMG1 =
    [
        HASH_SCENARIOID,
        HASH_SCENARIONAME,
        HASH_POWERSTARID,
        HASH_APPEARENCE,
        HASH_COMET,
        HASH_LUIGIMODETIMER,
        HASH_ISHIDDEN
    ];
    /// <summary>
    /// Array of Hashes that every Scenario BCSV will contain
    /// </summary>
    static readonly uint[] FixedHashesSMG2 =
    [
        HASH_SCENARIOID,
        HASH_SCENARIONAME,
        HASH_POWERSTARID,
        HASH_APPEARENCE,
        HASH_POWERSTARTYPE,
        HASH_COMET,
        HASH_COMETLIMITTIMER,
        HASH_LUIGIMODETIMER
    ];

    static readonly Dictionary<uint, BCSV.DataTypes> HashDataTypes = new()
    {
        { HASH_SCENARIOID, BCSV.DataTypes.INT32 },
        { HASH_SCENARIONAME, BCSV.DataTypes.STRING },
        { HASH_POWERSTARID, BCSV.DataTypes.INT32 },
        { HASH_APPEARENCE, BCSV.DataTypes.STRING },
        { HASH_POWERSTARTYPE, BCSV.DataTypes.STRING },
        { HASH_COMET, BCSV.DataTypes.STRING },
        { HASH_COMETLIMITTIMER, BCSV.DataTypes.INT32 },
        { HASH_LUIGIMODETIMER, BCSV.DataTypes.INT32 },
        { HASH_ISHIDDEN, BCSV.DataTypes.INT32 },
        { HASH_ERRORCHECK, BCSV.DataTypes.INT32 },

        { HASH_POWERSTARCOLOR, BCSV.DataTypes.INT32 },

        { HASH_ZONENAME, BCSV.DataTypes.STRING },
    };


    public ScenarioData()
    {

    }

    public ScenarioData(BCSV ScenarioDataBcsv, BCSV ZoneListBcsv)
    {
        for (int i = 0; i < ScenarioDataBcsv.EntryCount; i++)
        {
            BCSV.Entry curScenarioEntry = ScenarioDataBcsv[i];
            Scenario cur = new()
            {
                Name = (string)curScenarioEntry[ScenarioDataBcsv[HASH_SCENARIONAME]],
                ScenarioNo = (int)curScenarioEntry[ScenarioDataBcsv[HASH_SCENARIOID]],
                PowerStarID = (int)curScenarioEntry[ScenarioDataBcsv[HASH_POWERSTARID]],
                Appearence = (string)curScenarioEntry[ScenarioDataBcsv[HASH_APPEARENCE]],
                Comet = (string)curScenarioEntry[ScenarioDataBcsv[HASH_COMET]],
                LuigiTimeLimit = (int)curScenarioEntry[ScenarioDataBcsv[HASH_LUIGIMODETIMER]]
            };

            if (ScenarioDataBcsv.ContainsField(HASH_ISHIDDEN))
                cur.Type = (int)curScenarioEntry[ScenarioDataBcsv[HASH_ISHIDDEN]] > 0 ? "Hidden" : "Normal";

            // I'm doing this in this order in case someone makes this a thing in SMG1
            if (ScenarioDataBcsv.ContainsField(HASH_POWERSTARTYPE))
                cur.Type = (string)curScenarioEntry[ScenarioDataBcsv[HASH_POWERSTARTYPE]];


            if (ScenarioDataBcsv.ContainsField(HASH_COMETLIMITTIMER))
                cur.CometTimeLimit = (int)curScenarioEntry[ScenarioDataBcsv[HASH_COMETLIMITTIMER]];


            if (ScenarioDataBcsv.ContainsField(HASH_ERRORCHECK))
                cur.ErrorCheck = (int)curScenarioEntry[ScenarioDataBcsv[HASH_ERRORCHECK]];


            if (ScenarioDataBcsv.ContainsField(HASH_POWERSTARCOLOR))
                cur.PowerStarColor = (int)curScenarioEntry[ScenarioDataBcsv[HASH_POWERSTARCOLOR]];
            else
                cur.PowerStarColor = null;

            for (int j = 0; j < ZoneListBcsv.EntryCount; j++)
            {
                BCSV.Entry curZoneEntry = ZoneListBcsv[j];
                string ZoneName = (string)curZoneEntry[ZoneListBcsv[HASH_ZONENAME]];
                if (!ScenarioDataBcsv.ContainsField(BCSV.StringToHash_JGadget(ZoneName)))
                {
                    //ERROR
                    throw new Exception("Zone listed in ZoneList doesn't exist in ScenarioData");
                }

                Zone curZone = new()
                {
                    Name = ZoneName,
                    LayerMask = (int)curScenarioEntry[ScenarioDataBcsv[BCSV.StringToHash_JGadget(ZoneName)]]
                };
                cur.Zones.Add(curZone);
            }

            Add(cur);
        }
    }

    public void CreateBcsvFiles(bool IsSMG2, ReadOnlySpan<string> ZoneNames, out BCSV ScenarioDataBcsv, out BCSV ZoneListBcsv)
    {
        List<uint> HashList = [];
        if (IsSMG2)
            HashList.AddRange(FixedHashesSMG2);
        else
            HashList.AddRange(FixedHashesSMG1);

        if (InternalIsPowerStarColor())
            HashList.Add(HASH_POWERSTARCOLOR);

        if (InternalIsErrorCheck())
            HashList.Add(HASH_ERRORCHECK);

        ScenarioDataBcsv = new();
        for (int i = 0; i < HashList.Count; i++)
            ScenarioDataBcsv.Add(new BCSV.Field() { AutoRecalc = true, HashName = HashList[i], DataType = HashDataTypes[HashList[i]] });

        for (int i = 0; i < ZoneNames.Length; i++)
            ScenarioDataBcsv.Add(new BCSV.Field() { AutoRecalc = true, HashName = BCSV.StringToHash_JGadget(ZoneNames[i]), DataType = BCSV.DataTypes.INT32 });

        for (int i = 0; i < Count; i++)
        {
            Scenario c = this[i];
            BCSV.Entry e = new();
            e.Add(HASH_SCENARIONAME, c.Name);
            e.Add(HASH_SCENARIOID, c.ScenarioNo);
            e.Add(HASH_POWERSTARID, c.PowerStarID);
            e.Add(HASH_APPEARENCE, c.Appearence);
            e.Add(HASH_COMET, c.Comet);
            e.Add(HASH_LUIGIMODETIMER, c.LuigiTimeLimit);

            if (ScenarioDataBcsv.ContainsField(HASH_ISHIDDEN))
            {
                int IsHidden = c.Type.Equals("Hidden") ? 1 : 0;
                e.Add(HASH_ISHIDDEN, IsHidden);
            }
            // I'm doing this in this order in case someone makes this a thing in SMG1
            if (ScenarioDataBcsv.ContainsField(HASH_POWERSTARTYPE))
                e.Add(HASH_POWERSTARTYPE, c.Type);

            if (ScenarioDataBcsv.ContainsField(HASH_COMETLIMITTIMER))
                e.Add(HASH_COMETLIMITTIMER, c.CometTimeLimit);

            if (ScenarioDataBcsv.ContainsField(HASH_ERRORCHECK))
                e.Add(HASH_ERRORCHECK, c.ErrorCheck ?? 0);

            if (ScenarioDataBcsv.ContainsField(HASH_POWERSTARCOLOR))
                e.Add(HASH_POWERSTARCOLOR, c.PowerStarColor ?? 0);

            for (int j = 0; j < c.Zones.Count; j++)
                e.Add(BCSV.StringToHash_JGadget(c.Zones[j].Name), c.Zones[j].LayerMask);

            ScenarioDataBcsv.Add(e);
        }


        ZoneListBcsv = new();
        ZoneListBcsv.Add(new BCSV.Field() { AutoRecalc = true, HashName = HASH_ZONENAME, DataType = HashDataTypes[HASH_ZONENAME] });
        for (int i = 0; i < ZoneNames.Length; i++)
        {
            BCSV.Entry e = new();
            e.Add(HASH_ZONENAME, ZoneNames[i]);
            ZoneListBcsv.Add(e);
        }
    }

    private bool InternalIsPowerStarColor()
    {
        for (int i = 0; i < Count; i++)
        {
            Scenario CurScenarioEntry = this[i];
            if (CurScenarioEntry.PowerStarColor != null)
                return true;
        }
        return false;
    }
    private bool InternalIsErrorCheck()
    {
        for (int i = 0; i < Count; i++)
        {
            Scenario CurScenarioEntry = this[i];
            if (CurScenarioEntry.ErrorCheck != null)
                return true;
        }
        return false;
    }

    public struct Scenario
    {
        public string Name = "New Scenario";
        public int ScenarioNo;
        public int PowerStarID;
        public string Appearence = "";
        public string Type = "Normal";
        public string Comet = "";
        public int CometTimeLimit;
        public int LuigiTimeLimit;
        public int? ErrorCheck = null; // Never used...

        public int? PowerStarColor = null; //Preserving this. Null means it wasn't in the BCSV

        /// <summary>
        /// List of Zones
        /// </summary>
        public List<Zone> Zones = [];


        public Scenario() { }

        //TODO: TEST THIS
        public bool this[int StarID]
        {
            readonly get => (PowerStarID & (1 << StarID)) != 0;
            set => PowerStarID = (PowerStarID & ~(1 << StarID)) | ((value ? 1 : 0) << StarID);
        }

        public override readonly string ToString() => $"[{ScenarioNo}] {Name}";
    }

    public struct Zone
    {
        public const uint LAYER_MAX = 16;
        public string Name;
        public int LayerMask;

        //TODO: TEST THIS
        public bool this[int Layer]
        {
            readonly get => (LayerMask & (1 << Layer)) != 0;
            set => LayerMask = (LayerMask & ~(1 << Layer)) | ((value ? 1 : 0) << Layer);
        }

        public override readonly string ToString() => $"{Name} ({LayerMask:8})";
    }
}
