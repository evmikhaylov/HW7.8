using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace HW7._8
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using (FileStream FStream = new FileStream("ListWorker.txt", FileMode.Append))
			FStream.Close();

			#region раскоментировать для рандомного заполнения списка
			//Worker workerRandom = new Worker();
			//Random random = new Random();
			//for (int j = 0; j < 59; j++)
			//{
			//	workerRandom.IdWorker = File.ReadAllLines("ListWorker.txt").Length + 1;
			//	using (StreamWriter WriteTxt = new StreamWriter("ListWorker.txt", true))
			//	{
			//		workerRandom.DateTimeRecord = new DateTime(random.Next(1950, 2023), random.Next(1, 13), random.Next(1, 29), random.Next(0, 23), random.Next(0, 60), random.Next(0, 60));
			//		workerRandom.FullName = $"Имя{random.Next(1,1000)}";
			//		workerRandom.AgeWorker = (ushort)random.Next(18, 65);
			//		workerRandom.HeightWorker = (byte)random.Next(120, 220);
			//		workerRandom.BirthDay = new DateTime(random.Next(1950, 2023), random.Next(1, 13), random.Next(1, 29));
			//		workerRandom.PlaceBirth = $"Место{random.Next(1, 1000)}";

			//		WriteTxt.WriteLine($"{workerRandom.IdWorker}#{workerRandom.DateTimeRecord.ToString("g")}#{workerRandom.FullName}#{workerRandom.AgeWorker}#" +
			//			$"{workerRandom.HeightWorker}#{workerRandom.BirthDay.ToShortDateString()}#{workerRandom.PlaceBirth}");
			//		WriteTxt.Flush();
			//	}
			//}
			#endregion
			
			Repository repository = new Repository();

			while (true)
			{
				Console.WriteLine("Для просмотра списка сотрудников нажмите 1\nДля поиска сотрудника по id нажмите 2\nДобавить нового сотрудника в список нажмите 3" +
					"\nУдалить сотрудника из спика нажмите 4\nДля получения списка сотрудников зарегистрированных в выбранном диапазоне дат 5\nДля сортировки списка нажмите 6");
				switch(Console.ReadKey().Key)
				{
					case ConsoleKey.D1:
						{
							repository.GetAllWorkers();
							continue;
						}
					case ConsoleKey.D2:
						{
							Console.Clear();
                            Console.WriteLine("Введите id искомого сотрудника");
                            int Id = Int32.Parse(Console.ReadLine());
							repository.GetWorkerById(Id);
							continue;
						}
					case ConsoleKey.D3:
						{
							Console.Clear();
							Worker worker = new Worker();
							repository.AddWorker(worker);
							continue;
						}
					case ConsoleKey.D4:
						{
							Console.Clear();
                            Console.WriteLine("Введите id для удаления сотрудника");
							int Id = Int32.Parse(Console.ReadLine());
							repository.DeleteWorker(Id);
                            continue;
						}
					case ConsoleKey.D5:
						{
							Console.Clear();
                            Console.WriteLine("Введите начальную дату отбора сотрудников");
							DateTime dateFrom = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Введите конечную дату отбора сотрудников");
							DateTime dateTo = DateTime.Parse(Console.ReadLine());
							repository.GetWorkersBetweenTwoDates(dateFrom, dateTo);
                            continue;
						}
					case ConsoleKey.D6:
						{
							Worker[] orderedWorkers = repository.GetAllWorkers();
							Console.Clear();
							Console.WriteLine("Для сортировки сотрудников по:\n\tВремени записи нажмите 1\n\tИмени нажмите 2\n\tВозрасту нажмите 3" +
								"\n\tРосту нажмите 4\n\tДню рождения нажмите 5\n\tМесту рождения нажмите 6");
		{
								
								
								switch (Console.ReadKey().Key)
								{
									case ConsoleKey.D1:
										orderedWorkers = orderedWorkers.OrderBy(worker => worker.DateTimeRecord).ToArray();
										break;
									case ConsoleKey.D2:
										orderedWorkers = orderedWorkers.OrderBy(worker => worker.FullName).ToArray();
										break;
									case ConsoleKey.D3:
										orderedWorkers = orderedWorkers.OrderBy(worker => worker.AgeWorker).ToArray();
										break;
									case ConsoleKey.D4:
										orderedWorkers = orderedWorkers.OrderBy(worker => worker.HeightWorker).ToArray();
										break;
									case ConsoleKey.D5:
										orderedWorkers = orderedWorkers.OrderBy(worker => worker.BirthDay).ToArray();
										break;
									case ConsoleKey.D6:
										orderedWorkers = orderedWorkers.OrderBy(worker => worker.PlaceBirth).ToArray();
										break;
									default:
										break;
								}
								Console.Clear();
								foreach (var worker in orderedWorkers)
								{
									Console.WriteLine($"{worker.IdWorker} {worker.DateTimeRecord} {worker.FullName} {worker.AgeWorker} {worker.HeightWorker} {worker.BirthDay.ToShortDateString()}" +
											$" {worker.PlaceBirth}");
								}
								break;
							}

						}

				}
			}
		}
		
	}
}
