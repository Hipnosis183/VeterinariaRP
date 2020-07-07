using System;
using System.Linq;
using System.Threading.Tasks;
using VeterinariaRP.Web.Helpers;

namespace VeterinariaRP.Web.Data.Entities
{
    public class SeedDB
    {
        public readonly DataContext _Context;
        public readonly IUserHelper _UserHelper;
        
        public SeedDB(DataContext Context, IUserHelper UserHelper)
        {
            _Context = Context;
            _UserHelper = UserHelper;
        }

        public async Task SeedAsync()
        {
            await _Context.Database.EnsureCreatedAsync();

            await CheckRolesAsync();

            User Administrador = await CheckUserAsync("1010", "Renzo", "Pigliacampo", "renzo.pigliacampo@gmail.com", "350 634 2747", "Calle", "Admin");
            User Cliente = await CheckUserAsync("2020", "Renzo", "Pigliacampo", "renzo.pigliacampo@gmail.com", "350 634 2747", "Calle", "Cliente");

            await CheckAdministradoresAsync(Administrador);
            await CheckPropietariosAsync(Cliente);
            await CheckTipoMascotasAsync();
            await CheckMascotasAsync();
            await CheckTipoServiciosAsync();
            await CheckAgendasAsync();
        }

        private async Task CheckRolesAsync()
        {
            await _UserHelper.CheckRoleAsync("Admin");
            await _UserHelper.CheckRoleAsync("Cliente");
        }

        private async Task<User> CheckUserAsync(string Documento, string Nombre, string Apellido, string Email, string Telefono, string Direccion, string Rol)
        {
            User User = await _UserHelper.GetUserByEmailAsync(Email);

            if (User == null)
            {
                User = new User
                {
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Email = Email,
                    UserName = Email,
                    PhoneNumber = Telefono,
                    Direccion = Direccion,
                    Documento = Documento,
                };

                await _UserHelper.AddUserAsync(User, "123456");
                await _UserHelper.AddUserToRoleAsync(User, Rol);
            }

            return User;
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

        public async Task CheckPropietariosAsync(User User)
        {
            if (!_Context.Propietarios.Any())
            {
                _Context.Propietarios.Add(new Propietario { User = User });

                await _Context.SaveChangesAsync();
            }
        }

        public async Task CheckAdministradoresAsync(User User)
        {
            if (!_Context.Administradores.Any())
            {
                _Context.Administradores.Add(new Administrador { User = User });

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
