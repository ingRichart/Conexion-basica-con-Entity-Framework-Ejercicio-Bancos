
using EjercicioBancosAngelIbarra44361.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EjercicioBancosAngelIbarra44361.Controllers;

public class ClientesController : Controller
{
    private readonly ILogger<ClientesController> _logger;
    private readonly ApplicationDbContext _context;
    public ClientesController(ILogger<ClientesController>logger,ApplicationDbContext context)
    {
        _logger=logger;
        _context=context;
    }
    public IActionResult ClientesList()
    {
        List<ClientesModel> list=new List<ClientesModel>();
        list=_context.Clientes.Select(c=>new ClientesModel()
        {
            Id=c.Id,
            Name=c.Name,
            apellido=c.apellido,
            Direccion=c.Direccion,
            telefono=c.telefono,
            email=c.email
        }).ToList();
        return View(list);
    }
    public IActionResult ClientesAdd(ClientesModel clientes)
    {
        if(ModelState.IsValid)
       { Clientes clientesinfo =new Clientes();
       clientesinfo.Id =new Guid();
        clientesinfo.Name = clientes.Name;
        clientesinfo.apellido=clientes.apellido;
        clientesinfo.Direccion=clientes.Direccion;
        clientesinfo.telefono=clientes.telefono;
        clientesinfo.email=clientes.email;
        this._context.Clientes.Add(clientesinfo);
        this._context.SaveChanges();
       }
        return View();
    }
   [HttpGet]
    public IActionResult ClientesEdit(Guid Id)
    {
       
      Clientes clienteActualizar = this._context.Clientes.Where(c => c.Id == Id).FirstOrDefault();
    if (clienteActualizar == null)
    {
        return RedirectToAction("ClientesList");
    }

    ClientesModel model = new ClientesModel
    {
        Id = clienteActualizar.Id,
        Name = clienteActualizar.Name,
        apellido=clienteActualizar.apellido,
        Direccion = clienteActualizar.Direccion,
        telefono = clienteActualizar.telefono,
        email = clienteActualizar.email
    };
        return View(model);
    }
   
    [HttpPost]
    public IActionResult ClientesEdit(ClientesModel model)
    {
        if (ModelState.IsValid)
    {
        Clientes clientesActualizar = this._context.Clientes.Where(c => c.Id == model.Id).FirstOrDefault();
        if (clientesActualizar == null)
        {
            return RedirectToAction("ClientesList");
        }

        clientesActualizar.Name = model.Name;
        clientesActualizar.apellido=model.apellido;
        clientesActualizar.Direccion = model.Direccion;
        clientesActualizar.telefono = model.telefono;
        clientesActualizar.email = model.email;

        this._context.Clientes.Update(clientesActualizar);
        this._context.SaveChanges();

        return RedirectToAction("ClientesList");

    }
        return View(model);
    }
    
    [HttpGet]
    public IActionResult ClientesDeleted(Guid Id)
    {
       
      Clientes clientesborrado = this._context.Clientes.Where(c => c.Id == Id).FirstOrDefault();
    if (clientesborrado == null)
    {
        return RedirectToAction("ClientesList");
    }

    ClientesModel model = new ClientesModel
    {
        Id = clientesborrado.Id,
        Name = clientesborrado.Name,
        apellido=clientesborrado.apellido,
        Direccion = clientesborrado.Direccion,
        telefono = clientesborrado.telefono,
        email = clientesborrado.email
    };
        return View(model);
    }
   
    [HttpPost]
    public IActionResult ClientesDeleted(ClientesModel model)
    {
        var clientesBorrado = _context.Clientes.FirstOrDefault(c => c.Id == model.Id);
    if (clientesBorrado == null)
    {
        return RedirectToAction("ClientesList");
    }

    _context.Clientes.Remove(clientesBorrado);
    _context.SaveChanges();

    return RedirectToAction("ClientesList");
    }
   
      
}
