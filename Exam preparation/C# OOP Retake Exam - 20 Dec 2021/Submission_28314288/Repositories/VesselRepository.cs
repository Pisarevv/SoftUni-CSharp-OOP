namespace NavalVessels.Repositories
{
	using NavalVessels.Models.Contracts;
	using NavalVessels.Repositories.Contracts;
	using System.Collections.Generic;
	using System.Linq;

	public class VesselRepository : IRepository<IVessel>
	{
		private readonly HashSet<IVessel> models;

		public VesselRepository()
		{
			this.models = new HashSet<IVessel>();
		}

		public IReadOnlyCollection<IVessel> Models => this.models;

		public void Add(IVessel model) => this.models.Add(model);

		public IVessel FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);

		public bool Remove(IVessel model) => this.models.Remove(model);
	}
}
