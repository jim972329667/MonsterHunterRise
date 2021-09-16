using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Hunter_Rise
{
	class Item : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly uint mAddress;

		public Item(uint address, uint caseNumber, uint cases)
		{
			mAddress = address;
			CaseNumber = caseNumber;
			Case = cases;
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 36, 2); }
			set
			{
				SaveData.Instance().WriteNumber(mAddress + 36, 2, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Count
		{
			get { return SaveData.Instance().ReadNumber(mAddress + 52, 4); }
			set
			{
				Util.WriteNumber(mAddress + 52, 4, value, 0, 9999);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
			}
		}

        public uint CaseNumber {private set; get; }
		public uint Case {private set; get; }

	}
}
