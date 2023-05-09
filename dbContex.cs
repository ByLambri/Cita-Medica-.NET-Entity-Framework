using citamedica.Model;
using Microsoft.EntityFrameworkCore;

namespace citamedica
{
    public class dbContex : DbContext
    {
        public dbContex() { }

        public dbContex(DbContextOptions<dbContex>options) : base(options) { }

        public virtual DbSet<Usuario>Usuarios { get; set; }

        public virtual DbSet<Paciente> Pacientes { get; set; }

        public virtual DbSet<Medico> Medicos { get; set; }

        public virtual DbSet<Diagnostico> Diagnosticos { get; set; }

        public virtual DbSet<Cita> Citas { get; set; }

        public virtual DbSet<MedicoPaciente> MedicosPacientes { get; set; }
        public object Medico { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>()
                .HasMany(many => many.Pacientes)
                .WithOne(one => one.Medico)
                .HasForeignKey(fk => fk.PacienteId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Cita>()
            //.HasOne(one => one.Medico)
            //.WithOne(many => many.Citas)
            //.HasForeignKey(fk => fk.medicoId)
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cita>()
            .HasOne(c => c.Medico)
            .WithMany(m => m.Citas)
            .HasForeignKey(c => c.MedicoId)
            .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Cita>()
           .HasOne(c => c.Paciente)
           .WithMany(m => m.Citas)
           .HasForeignKey(c => c.PacienteId)
           .OnDelete(DeleteBehavior.ClientCascade);


            modelBuilder.Entity<MedicoPaciente>()
            .HasOne<Paciente>(one => one.Paciente)
            .WithMany(many => many.Medicos)
            .HasForeignKey(fk => fk.PacienteId)
            .OnDelete(DeleteBehavior.ClientCascade);


            modelBuilder.Entity<MedicoPaciente>()
            .HasOne<Medico>(one => one.Medico)
            .WithMany(many => many.Pacientes)
            .HasForeignKey(fk => fk.MedicoId)
            .OnDelete(DeleteBehavior.ClientCascade);

            //modelBuilder.Entity<Cita>()
            //.HasOne(one => one.Paciente)
            //.WithOne(many => many.cita)
            // .HasForeignKey(fk => fk.PacienteId)


            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Diagnostico)
                .WithOne(d => d.cita)
                .HasForeignKey<Diagnostico>(e => e.CitaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Paciente>()
                .HasMany(many => many.Medicos)
                .WithOne(one => one.Paciente)
                .HasForeignKey(fk => fk.MedicoId)
                .OnDelete(DeleteBehavior.Cascade);

            


            base.OnModelCreating(modelBuilder);
        }
    }

    
}
