using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dota2.Properties;

namespace Dota2
{
	/// <summary>
	/// Хранит массив ссылок на иконки героев
	/// </summary>
	static class HeroIcons
	{
		public static System.Drawing.Bitmap[] Icons = { 
			Resources.Abaddon,
			Resources.AncientApparition,
			Resources.AntiMage,
			Resources.Axe,
			Resources.Bane,
			Resources.Batrider,
			Resources.BeastMaster,
			Resources.BountyHunter,
			Resources.Bristleback,
			Resources.Broodmother,
			Resources.CentaurWarrunner,
			Resources.ChaosKnight,
			Resources.Chen,
			Resources.Clinkz,
			Resources.Clockwerk,
			Resources.Darkseer,
			Resources.DefaultIcon, // Dark Willow не было(
			Resources.Dazzle,
			Resources.DeathProphet,
			Resources.Disruptor,
			Resources.Doom,
			Resources.DragonKnight,
			Resources.Drowranger,
			Resources.EarthSpirit,
			Resources.Earthshaker,
			Resources.ElderTitan,
			Resources.EmberSpirit,
			Resources.Enchantress,
			Resources.Enigma,
			Resources.FacelessVoid,
			Resources.Gyrocopter,
			Resources.Huskar,
			Resources.Juggernaut,
			Resources.KeeperOfLight,
			Resources.Kunkka,
			Resources.LegionCommander,
			Resources.Lich,
			Resources.Lifestealer,
			Resources.Lina,
			Resources.Lion,
			Resources.LoneDruid,
			Resources.Luna,
			Resources.Lycan,
			Resources.Magnus,
			Resources.Medusa,
			Resources.Meepo,
			Resources.Mirana,
			Resources.DefaultIcon, // Monkey King не было((
			Resources.Morphling,
			Resources.NagaSiren,
			Resources.NaturesProphet,
			Resources.Necrophos,
			Resources.NightStalker,
			Resources.NyxAssasin,
			Resources.OgreMagi,
			Resources.Omniknight,
			Resources.Oracle,
			Resources.DefaultIcon, // Pangolier не было((
			Resources.PhantomAssasin,
			Resources.Puck,
			Resources.Pudge,
			Resources.Pugna,
			Resources.QueenOfPain,
			Resources.Razor,
			Resources.Riki,
			Resources.Rubick,
			Resources.SandKing,
			Resources.ShadowDemon,
			Resources.ShadowFiend,
			Resources.ShadowShaman,
			Resources.Silencer,
			Resources.SkywrathMage,
			Resources.Slardar,
			Resources.Slark,
			Resources.Sniper,
			Resources.Spectre,
			Resources.SpiritBreaker,
			Resources.StormSpirit,
			Resources.Sven,
			Resources.Techies,
			Resources.TemplarAssasin,
			Resources.Terrorblade,
			Resources.Tidehunter,
			Resources.Timbersaw,
			Resources.Tinker,
			Resources.Tiny,
			Resources.TreantProtector,
			Resources.TrollWarlord,
			Resources.Underlord,
			Resources.Ursa,
			Resources.VengefulSpirit,
			Resources.Venomancer,
			Resources.Viper,
			Resources.Visage,
			Resources.Warlock,
			Resources.Windranger,
			Resources.WitchDoctor,
			Resources.WrathKing,
			Resources.Zeus
		};

		public static System.Drawing.Bitmap GetIcon(int index)
		{
			return Icons[index];
		}


	}
}
