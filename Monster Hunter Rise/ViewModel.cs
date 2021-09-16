﻿using System;
using System.Collections.ObjectModel;

namespace Monster_Hunter_Rise
{
	class ViewModel
	{
		private readonly byte[] CaseItemAddress = { 0x59, 0xCD, 0x75, 0xF9, 0xFF, 0xFF, 0xFF, 0xFF, 0x11, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x43, 0xD4, 0xB9, 0x35, 0x1C, 0x95, 0xB3, 0xC2, 0x11, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x37, 0xE3, 0xD2, 0x54, 0x0F, 0x5D, 0x48, 0xAF, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x16, 0xA9, 0x11, 0x8C, 0x07, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xE2, 0x73, 0x2D, 0xF6, 0x11, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x61, 0x61, 0x69, 0x67, 0xEE, 0xE7, 0x96, 0x79, 0xFF, 0xFF, 0xFF, 0xFF, 0x11, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0xB0, 0x04, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 };
		private readonly byte[] MoneyAddress = { 0x76, 0xBB, 0xDB, 0x63, 0x09, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00 };
		public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
		public ViewModel()
		{
			uint ItemAddress = SaveData.Instance().FindAddress(CaseItemAddress);
			if(ItemAddress != 0)
            {
                uint mycase = 0;
				for (uint i = 0; i < Util.ITEM_COUNT; i++)
				{
                    if ((i + 1) % 100 == 1)
                    {
						mycase++;
                    }
					uint address = ItemAddress + Util.ITEM_SIZE * i;
					Item item = new Item(address, i + 1 - (mycase - 1) * 100, mycase);
					//if (item.ID == 0) continue;
					//if (item.Count == 0) continue;

					Items.Add(item);
				}
			}

		}

		public uint Money
		{
			get { return SaveData.Instance().ReadNumber(SaveData.Instance().FindAddress(MoneyAddress) + 4, 4); }
			set { Util.WriteNumber(SaveData.Instance().FindAddress(MoneyAddress) + 4, 4, value, 0, 99999999); }
		}
	}
}
