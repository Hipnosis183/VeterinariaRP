using System;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinariaRP.Web.Data.Entities
{
    public class SeedDB
    {
        public readonly DataContext _Context;
        
        public SeedDB(DataContext Context)
        {
            _Context = Context;
        }

        public async Task SeedAsync()
        {
            await _Context.Database.EnsureCreatedAsync();
        }

        public async Task CheckTipoServiciosAsync()
        {
            if (!_Context.TipoServicios.Any())
            {
                _Context.TipoServicios.Add(new TipoServicio { Nombre = "Consulta" });
                _Context.TipoServicios.Add(new TipoServicio { Nombre = "Urgencia" });
                _Context.TipoServicios.Add(new TipoServicio { Nombre = "Vacunación" });

                await _Context.SaveChangesAsync();
            }
        }

        public async Task CheckTipoMascotasAsync()
        {
            if (!_Context.TipoMascotas.Any())
            {
                _Context.TipoMascotas.Add(new TipoMascota { Nombre = "Gato" });
                _Context.TipoMascotas.Add(new TipoMascota { Nombre = "Perro" });

                await _Context.SaveChangesAsync();
            }
        }

        public async Task CheckPropietariosAsync()
        {
            if (!_Context.Propietarios.Any())
            {
                AddPropietarios("3125895", "Juan", "Soto", "231 3232", "341 5453221", "Calle Mitre 1111");
                AddPropietarios("6321456", "José", "Cardona", "343 3226", "346 508701", "Calle Belgrano 112");
                AddPropietarios("6565897", "María", "López", "450 4323", "341 151515", "José Ingeniero 123");

                await _Context.SaveChangesAsync();
            }
        }

        public async Task CheckMascotasAsync()
        {
            Propietario Propietario = _Context.Propietarios.FirstOrDefault();
            TipoMascota TipoMascota = _Context.TipoMascotas.FirstOrDefault();

            if (!_Context.Mascotas.Any())
            {
                AddMascotas("Otto", Propietario, TipoMascota, "Shih Tzu");
                AddMascotas("Killer", Propietario, TipoMascota, "Dobermann");

                await _Context.SaveChangesAsync();
            }
        }

        public async Task CheckAgendasAsync()
        {
            if (!_Context.Agendas.Any())
            {
                DateTime InitialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                DateTime FinalDate = InitialDate.AddYears(1);

                while (InitialDate < FinalDate)
                {
                    if (InitialDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        DateTime FinalDateDay = InitialDate.AddHours(10);

                        while (InitialDate < FinalDateDay)
                        {
                            _Context.Agendas.Add(new Agenda { Fecha = InitialDate.ToUniversalTime(), IsDisponible = true });

                            InitialDate = InitialDate.AddMinutes(30);
                        }

                        InitialDate = InitialDate.AddHours(14);
                    }

                    else
                    {
                        InitialDate = InitialDate.AddDays(1);
                    }
                }

                await _Context.SaveChangesAsync();
            }
        }

        private void AddPropietarios(string Documento, string Nombre, string Apellido, string TelCelular, string TelFijo, string Direccion)
        {
            _Context.Propietarios.Add(new Propietario
            {
                Documento = Documento,
                Nombre = Nombre,
                Apellido = Apellido,
                TelCelular = TelCelular,
                TelFijo = TelFijo,
                Direccion = Direccion
            });
        }

        private void AddMascotas(string Nombre, Propietario Propietario, TipoMascota TipoMascota, string Raza)
        {
            _Context.Mascotas.Add(new Mascota
            {
                Nacimiento = DateTime.Now.AddYears(-2),
                Nombre = Nombre,
                Propietario = Propietario,
                TipoMascota = TipoMascota,
                Raza = Raza
            });
        }
    }
}
