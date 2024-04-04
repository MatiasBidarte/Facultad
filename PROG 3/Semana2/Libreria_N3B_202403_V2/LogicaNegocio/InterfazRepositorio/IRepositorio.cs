﻿namespace LogicaNegocio.InterfazRepositorio
{
	public interface IRepositorio <T>
	{
		public void Add(T obj);

		public void Update(int id, T obj);

		public void Delete(int id);

		public List<T> GetAll();

		public T GetById(int id);
	}
}

