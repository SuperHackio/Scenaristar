using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hack.io.BCSV;

namespace GalaxyMaps
{
    public class ScenarioSMG2
    {
        /// <summary>
        /// Defines the Types of Stars that Super Mario Galaxy 2 has.
        /// Default - Normal
        /// </summary>
        public enum StarType {
            /// <summary>
            /// A Normal star.
            /// </summary>
            Normal,
            /// <summary>
            /// A Hidden star.
            /// </summary>
            Hidden,
            /// <summary>
            /// A Green Star.
            /// </summary>
            Green,
#if DEBUG
            /// <summary>
            /// Needs to be hacked into the game.
            /// </summary>
            Red,
            /// <summary>
            /// Needs to be hacked into the game.
            /// </summary>
            Grand
#endif
        }
        /// <summary>
        /// Defines the Types of Comets that Super Mario Galaxy 2 has.
        /// Default - None
        /// </summary>
        public enum CometType {
            /// <summary>
            /// No comet
            /// </summary>
            None,
            /// <summary>
            /// Speedrun (Required Comet Timer)
            /// </summary>
            Red,
            /// <summary>
            /// Collect 100 Purple Coins (Optional Comet Timer)
            /// </summary>
            Purple,
            /// <summary>
            /// Daredevil, 1 HP
            /// </summary>
            Dark,
            /// <summary>
            /// Romp Comet (Required Comet Timer)
            /// </summary>
            Exterminate,
            /// <summary>
            /// Cosmic Clones
            /// </summary>
            Mimic,
            /// <summary>
            /// Double Time Comet
            /// </summary>
            Quick }

        /// <summary>
        /// Internal name of the Scenario
        /// </summary>
        public string Name = "New Star";
        /// <summary>
        /// ID of the scenario
        /// </summary>
        public int Number = 1;
        /// <summary>
        /// Determines which stars are shown in the mission
        /// </summary>
        public int PowerStarID;
        /// <summary>
        /// The ID of the Object that Spawns the Star
        /// </summary>
        public string Appearence = "";
        /// <summary>
        /// Type of Star
        /// </summary>
        public StarType Type;
        /// <summary>
        /// The Comet attached to this Scenario
        /// </summary>
        public CometType Comet;
        /// <summary>
        /// Time limit for Comets. Only needed for <see cref="CometType.Red" />, <see cref="CometType.Exterminate" />, and optionally <see cref="CometType.Purple" />.
        /// </summary>
        public int TimeLimit;
        public int LuigiTimeLimit;
        public int Unknown;
        /// <summary>
        /// List of Zones
        /// </summary>
        public List<Zone> Zones = new List<Zone>();

        /// <summary>
        /// Creates an empty Scenario.<para />
        /// Name = "New Star" |
        /// Number = 1 |
        /// PowerStarID = 0 |
        /// Appearence = "" |
        /// Type = <see cref="StarType.Normal"/> |
        /// Comet = <see cref="CometType.None"/> |
        /// Timelimit = 0
        /// <para />
        /// WARNING! <see cref="Zones"/> will be empty!
        /// </summary>
        public ScenarioSMG2()
        {

        }
        /// <summary>
        /// Creates an empty Scenario.<para />
        /// Name = "New Star" |
        /// Number = 1 |
        /// PowerStarID = 0 |
        /// Appearence = "" |
        /// Type = <see cref="StarType.Normal"/> |
        /// Comet = <see cref="CometType.None"/> |
        /// Timelimit = 0
        /// <para />
        /// <see cref="Zones"/> will contain the zones passed in from the input Zone List
        /// </summary>
        /// <param name="Z">List of <see cref="Zone"/>s to give to this <see cref="ScenarioSMG2"/></param>
        public ScenarioSMG2(List<Zone> Z) { Zones = Z; }

        /// <summary>
        /// Calculates the new PowerStarID
        /// </summary>
        /// <param name="Checks">Checkbox array. Must be length == 6 or Length == 8</param>
        public void CalculateStarID(System.Windows.Forms.CheckBox[] Checks)
        {
            int starmask = 0;
            if (Checks[0].Checked) starmask ^= 1;
            if (Checks[1].Checked) starmask ^= 2;
            if (Checks[2].Checked) starmask ^= 4;
            if (Checks[3].Checked) starmask ^= 8;
            if (Checks[4].Checked) starmask ^= 16;
            if (Checks[5].Checked) starmask ^= 32;
            if (Checks.Length < 6 && Checks[6].Checked) starmask ^= 64;
            if (Checks.Length < 6 && Checks[7].Checked) starmask ^= 128;
            PowerStarID = starmask;
        }
        /// <summary>
        /// Creates an array of Booleans based on this Scenario's <see cref="PowerStarID"/>
        /// </summary>
        /// <param name="Input"><see cref="PowerStarID"/></param>
        /// <param name="UseLast">Determines if this function should go to 8 stars or not</param>
        /// <returns></returns>
        public bool[] CalculateStarID(int Input, bool UseLast)
        {
            int starmask = Input;
            bool chkStar1 = ((starmask & 1) != 0);
            bool chkStar2 = ((starmask & 2) != 0);
            bool chkStar3 = ((starmask & 4) != 0);
            bool chkStar4 = ((starmask & 8) != 0);
            bool chkStar5 = ((starmask & 16) != 0);
            bool chkStar6 = ((starmask & 32) != 0);
            bool chkStar7 = ((starmask & 64) != 0);
            bool chkStar8 = ((starmask & 128) != 0);
            if (UseLast)
                return new bool[8] { chkStar1, chkStar2, chkStar3, chkStar4, chkStar5, chkStar6, chkStar7, chkStar8 };
            else
                return new bool[6] { chkStar1, chkStar2, chkStar3, chkStar4, chkStar5, chkStar6 };
        }

        /// <summary>
        /// Makes a new Object Array that can be put into a BCSV entry
        /// </summary>
        /// <returns>object[]</returns>
        public Dictionary<uint, object> MakeBCSVEntry(uint[] HashList)
        {
            Dictionary<uint, object> Data = new Dictionary<uint, object>()
            {
                { HashList[0], this.Number },
                { HashList[1], this.Name },
                { HashList[2], this.PowerStarID },
                { HashList[3], this.Appearence },
                { HashList[4], this.Type.ToString() },
                { HashList[5], this.Comet == CometType.None ? "" : this.Comet.ToString() },
                { HashList[6], this.TimeLimit},
                { HashList[7], 0 },
                { HashList[8], 0 }
            };

            for (int i = 0; i < Zones.Count; i++)
                Data.Add(BCSV.FieldNameToHash(Zones[i].Name), Zones[i].Calculate());

            return Data;
        }

        /// <summary>
        /// Makes a new UInt Array that can be put into a BCSV Entry
        /// </summary>
        /// <param name="Strings">List of Camera Types to include</param>
        /// <returns>uint[]</returns>
        public uint[] GetStringOffsets(List<List<string>> StringListCollection, int ID = -1, int Fieldcount = 10)
        {
            uint[] returnmeplz = new uint[Fieldcount];

            uint NameOffset = 0; //Offset to the Star Name which comes first
            uint AppearenceOffset = 0; //Offset to the Appearence
            uint TypeOffset = 0; //Offset to the Star Type
            uint CometOffset = 0; //Offset to the Comet Type

            uint OffsetToAppearence = 0; //Offset to where the Appearence start.
            uint OffsetToType = 0; //Offset to where the Appearence start.
            uint OffsetToComet = 0; //Offset to where the Appearence start.

            System.Text.Encoding enc = System.Text.Encoding.GetEncoding(932);

            #region
            foreach (string s in StringListCollection[0])
                OffsetToAppearence += (uint)(enc.GetBytes(s).Length + 1);

            OffsetToType += OffsetToAppearence;

            foreach (string s in StringListCollection[1])
                OffsetToType += (uint)(enc.GetBytes(s).Length + 1);

            OffsetToComet += OffsetToType;

            foreach (string s in StringListCollection[2])
                OffsetToComet += (uint)(enc.GetBytes(s).Length + 1);

            AppearenceOffset = OffsetToAppearence;
            TypeOffset = OffsetToType;
            CometOffset = OffsetToComet;

            for (int i = 0; i < StringListCollection[0].Count; i++)
            {
                if (i == ID)
                    break;
                NameOffset += (uint)enc.GetBytes(StringListCollection[0][i]).Length + 1;
            }

            for (int i = 0; i < StringListCollection[1].Count; i++)
            {
                if (i == ID | StringListCollection[1][i] == this.Appearence)
                    break;
                AppearenceOffset += (uint)enc.GetBytes(StringListCollection[1][i]).Length + 1;
            }

            for (int i = 0; i < StringListCollection[2].Count; i++)
            {
                if (i == ID)
                    break;
                if (ID >= StringListCollection[2].Count)
                    break;
                TypeOffset += (uint)enc.GetBytes(StringListCollection[2][i]).Length + 1;
            }

            for (int i = 0; i < StringListCollection[3].Count; i++)
            {
                if (i == ID)
                    break;
                if (ID >= StringListCollection[3].Count)
                    break;
                CometOffset += (uint)enc.GetBytes(StringListCollection[3][i]).Length + 1;
            }


            returnmeplz[0] = 0;
            returnmeplz[1] = NameOffset;
            returnmeplz[2] = 0;
            returnmeplz[3] = AppearenceOffset;
            returnmeplz[4] = TypeOffset;
            returnmeplz[5] = CometOffset;
            #endregion

            return returnmeplz;
        }
    }

    public partial class Zone
    {
        public string Name;
        public bool[] Layers = new bool[16];

        /// <summary>
        /// Creates a Zone
        /// </summary>
        /// <param name="N">Name of this Zone</param>
        public Zone(string N) => Name = N;
        /// <summary>
        /// Loads a Zone
        /// </summary>
        /// <param name="N">Name of this Zone</param>
        /// <param name="L">Numerical value of the Active Layers</param>
        public Zone(string N, int L)
        {
            Name = N;
            int layermask = L;
            Layers[0] = ((layermask & 1) != 0);
            Layers[1] = ((layermask & 2) != 0);
            Layers[2] = ((layermask & 4) != 0);
            Layers[3] = ((layermask & 8) != 0);
            Layers[4] = ((layermask & 16) != 0);
            Layers[5] = ((layermask & 32) != 0);
            Layers[6] = ((layermask & 64) != 0);
            Layers[7] = ((layermask & 128) != 0);
            Layers[8] = ((layermask & 256) != 0);
            Layers[9] = ((layermask & 512) != 0);
            Layers[10] = ((layermask & 1024) != 0);
            Layers[11] = ((layermask & 2048) != 0);
            Layers[12] = ((layermask & 4096) != 0);
            Layers[13] = ((layermask & 8192) != 0);
            Layers[14] = ((layermask & 16384) != 0);
            Layers[15] = ((layermask & 32768) != 0);
        }
        
        /// <summary>
        /// Calculates the Numerical Value of this Zone's Active Layers
        /// </summary>
        /// <returns>Numerical value of the Active Layers</returns>
        public int Calculate()
        {
            int layermask = 0;
            if (Layers[0]) layermask ^= 1;
            if (Layers[1]) layermask ^= 2;
            if (Layers[2]) layermask ^= 4;
            if (Layers[3]) layermask ^= 8;
            if (Layers[4]) layermask ^= 16;
            if (Layers[5]) layermask ^= 32;
            if (Layers[6]) layermask ^= 64;
            if (Layers[7]) layermask ^= 128;
            if (Layers[8]) layermask ^= 256;
            if (Layers[9]) layermask ^= 512;
            if (Layers[10]) layermask ^= 1024;
            if (Layers[11]) layermask ^= 2048;
            if (Layers[12]) layermask ^= 4096;
            if (Layers[13]) layermask ^= 8192;
            if (Layers[14]) layermask ^= 16384;
            if (Layers[15]) layermask ^= 32768;

            return layermask;
        }
    }
}
