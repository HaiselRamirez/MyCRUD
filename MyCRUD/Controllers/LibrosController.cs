using Microsoft.AspNetCore.Mvc;
using MyCRUD.Data;
using MyCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCRUD.Controllers
{
	public class LibrosController : Controller
	{
		#region Miembros
		private readonly ApplicationDbContext _context;
		#endregion

		#region Constructor
		public LibrosController(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion

		#region Index
		public IActionResult Index()
		{
			IEnumerable<Libro> listaLibros = _context.Libro;
			return View(listaLibros);
		}
		#endregion

		#region Create Formulario para crear un nuevo libro
		public IActionResult Create()
		{

			return View();
		}
		#endregion

		#region Metodo HttpPost para agregar un nuevo libro
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Libro libro)
		{
			if (ModelState.IsValid)
			{
				_context.Libro.Add(libro);
				_context.SaveChanges();
				TempData["mensaje"] = "El libro se ha guardado correctamente";
				return RedirectToAction("Index");
			}
			return View();
		}
		#endregion

		#region Formulario para editar un libro
		public IActionResult Edit(int? id)
		{
			if(id == null || id.Equals(0))
			{
				return NotFound();
			}

			//Obtener libro 
			var libro = _context.Libro.Find(id);
			if(libro == null)
			{
				return NotFound();
			}
			return View(libro);
		}
		#endregion

		#region Metodo HttpPost para editar un libro
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Libro libro)
		{
			if (ModelState.IsValid)
			{
				_context.Libro.Update(libro);
				_context.SaveChanges();

				TempData["mensaje"] = " El libro se actualizó correctamente";
				return RedirectToAction("Index");
			}
			return View();
		}
		#endregion

		#region Formulario para eliminar un libro
		public IActionResult Delete(int? id)
		{
			if (id == null || id.Equals(0))
			{
				return NotFound();
			}

			//Obtener libro 
			var libro = _context.Libro.Find(id);
			if (libro == null)
			{
				return NotFound();
			}
			return View(libro);
		}
		#endregion

		#region Metodo HttpPost para editar un libro
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteLibro(int? id)
		{
			if(id == null || id.Equals(0))
			{
				return NotFound();
			}
			//Obtener el libro
			var libro = _context.Libro.Find(id);
			if(libro == null)
			{
				return NotFound();
			}
				_context.Libro.Remove(libro);
				_context.SaveChanges();

				TempData["mensaje"] = " El libro se ha eliminado correctamente";
				return RedirectToAction("Index");
		}
		#endregion

	}
}
