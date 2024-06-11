
using EjercicioBancosAngelIbarra44361.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EjercicioBancosAngelIbarra44361.Controllers;

public class BancosController : Controller
{
    private readonly ILogger<BancosController> _logger;
    private readonly ApplicationDbContext _context;
    public BancosController(ILogger<BancosController>logger,ApplicationDbContext context)
    {
        _logger=logger;
        _context=context;
    }
    public IActionResult BancosList()
    {
        List<BancosModel> list=new List<BancosModel>();
        list=_context.Bancos.Select(b=>new BancosModel()
        {
            Id=b.Id,
            Name=b.Name,
            Direccion=b.Direccion,
            telefono=b.telefono,
            email=b.email
        }).ToList();
        return View(list);
    }
    public IActionResult BancosAdd(BancosModel bancos)
    {
        if(ModelState.IsValid)
       { Bancos bancoinfo =new Bancos();
       bancoinfo.Id =new Guid();
        bancoinfo.Name = bancos.Name;
        bancoinfo.Direccion=bancos.Direccion;
        bancoinfo.telefono=bancos.telefono;
        bancoinfo.email=bancos.email;
        this._context.Bancos.Add(bancoinfo);
        this._context.SaveChanges();
       }
        return View();
    }
   [HttpGet]
    public IActionResult BancosEdit(Guid Id)
    {
       
      Bancos bancoActualizar = this._context.Bancos.Where(b => b.Id == Id).FirstOrDefault();
    if (bancoActualizar == null)
    {
        return RedirectToAction("BancosList");
    }

    BancosModel model = new BancosModel
    {
        Id = bancoActualizar.Id,
        Name = bancoActualizar.Name,
        Direccion = bancoActualizar.Direccion,
        telefono = bancoActualizar.telefono,
        email = bancoActualizar.email
    };
        return View(model);
    }
   
    [HttpPost]
    public IActionResult BancosEdit(BancosModel model)
    {
        if (ModelState.IsValid)
    {
        Bancos bancoActualizar = this._context.Bancos.Where(b => b.Id == model.Id).FirstOrDefault();
        if (bancoActualizar == null)
        {
            return RedirectToAction("BancosList");
        }

        bancoActualizar.Name = model.Name;
        bancoActualizar.Direccion = model.Direccion;
        bancoActualizar.telefono = model.telefono;
        bancoActualizar.email = model.email;

        this._context.Bancos.Update(bancoActualizar);
        this._context.SaveChanges();

        return RedirectToAction("BancosList");

    }
        return View(model);
    }
     [HttpGet]
    public IActionResult BancosDeleted(Guid Id)
    {
       
      Bancos bancoborrado = this._context.Bancos.Where(b => b.Id == Id).FirstOrDefault();
    if (bancoborrado == null)
    {
        return RedirectToAction("BancosList");
    }

    BancosModel model = new BancosModel
    {
        Id = bancoborrado.Id,
        Name = bancoborrado.Name,
        Direccion = bancoborrado.Direccion,
        telefono = bancoborrado.telefono,
        email = bancoborrado.email
    };
        return View(model);
    }
   
    [HttpPost]
    public IActionResult BancosDeleted(BancosModel model)
    {
       Bancos bancosBorrado = _context.Bancos.FirstOrDefault(c => c.Id == model.Id);
    if (bancosBorrado == null)
    {
        return RedirectToAction("BancosList");
    }

    _context.Bancos.Remove(bancosBorrado);
    _context.SaveChanges();

    return RedirectToAction("BancosList");
    }
   
      
}
