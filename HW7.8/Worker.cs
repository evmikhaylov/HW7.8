using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7._8
{
	public struct Worker
	{
				
		public Worker(int IdWorker, DateTime DateTimeRecord, string FullName, ushort AgeWorker, byte HeightWorker, DateTime BirthDay, string PlaceBirth)
		{
			this.idWorker = IdWorker;
			this.dateTimeRecord = DateTimeRecord;
			this.fullName = FullName;
			this.ageWorker = AgeWorker;
			this.heightWorker = HeightWorker;
			this.birthDay = BirthDay;
			this.placeBirth = PlaceBirth;

		}

		public int IdWorker { get { return this.idWorker; } set { this.idWorker = value; } }
		public DateTime DateTimeRecord { get { return this.dateTimeRecord; } set { this.dateTimeRecord = value; } }
		public string FullName { get { return this.fullName; } set { this.fullName = value; } }
		public ushort AgeWorker { get { return this.ageWorker; } set { this.ageWorker = value; } }
		public byte HeightWorker { get { return this.heightWorker; } set { this.heightWorker = value; } }
		public DateTime BirthDay { get { return this.birthDay; } set { this.birthDay = value; } }
		public string PlaceBirth { get { return this.placeBirth; } set { this.placeBirth = value; } }


		private int idWorker;
		private DateTime dateTimeRecord;
		private string fullName;
		private ushort ageWorker;
		private byte heightWorker;
		private DateTime birthDay;
		private string placeBirth;
		


	}
}
