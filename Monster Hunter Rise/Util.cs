namespace Monster_Hunter_Rise
{
	class Util
	{
		public const uint ITEM_COUNT = 1200;
		public const uint ITEM_SIZE = 0x38;


		public static void WriteNumber(uint address, uint size, uint value, uint min, uint max)
		{
			if (value < min) value = min;
			if (value > max) value = max;
			SaveData.Instance().WriteNumber(address, size, value);
		}

		public static uint ItemIDAddress(uint id)
		{
			return 0x4C + id * 8;
		}
	}
}
