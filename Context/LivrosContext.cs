using Microsoft.EntityFrameworkCore;
using ProjetoLivros_Home.Models;

namespace ProjetoLivros_Home.Context
{
    public class LivrosContext : DbContext
    {
        //cada tabela um DbSet
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }

        //construtor
        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string de conexão
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-SAUC46V;Initial Catalog=Livros;Integrated Security=true;TrustServerCertificate=true;");
        }

        //Configuração de cada tabela e suas colunas do BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(

                entity =>
                {
                    //Primary Key
                    entity.HasKey(u => u.UsuarioId);

                    entity.Property(u => u.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                    entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                    //email é unico
                    entity.HasIndex(u => u.Email)
                    .IsUnique();

                    entity.Property(u => u.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                    entity.Property(u => u.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                    entity.Property(u => u.DataCadastro)
                    .IsRequired();

                    entity.Property(u => u.DataAtualizacao)
                    .IsRequired();

                    entity.HasOne(u => u.TipoUsuario)
                    .WithMany(t => t.Usuarios)
                    .HasForeignKey(u => u.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);

                }
            );

            modelBuilder.Entity<Livro>(

                entity =>
                {
                    entity.HasKey(l => l.LivroId);

                    entity.Property(l => l.Titulo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                    entity.Property(l => l.Autor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                    entity.Property(l => l.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                    entity.Property(l => l.DataPublicacao)
                    .IsRequired();

                    entity.HasOne(l => l.Categoria)
                    .WithMany(c => c.Livros)
                    .HasForeignKey(l => l.CategoriaId)
                    .OnDelete(DeleteBehavior.Cascade);
                }
            );

            modelBuilder.Entity<Assinatura>(
                entity =>
                {
                    entity.HasKey(a => a.AssinaturaId);

                    entity.Property(a => a.DataInicio)
                    .IsRequired();

                    entity.Property(a => a.DataFim)
                    .IsRequired();

                    entity.Property(a => a.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                    //entender e refazer a chave estrangeira
                    entity.HasOne(a => a.Usuario)
                    .WithMany()
                    .HasForeignKey(a => a.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
                }

            );

            modelBuilder.Entity<Categoria>(

                entity =>
                {
                    entity.HasKey(c => c.CategoriaId);

                    entity.Property(c => c.NomeCategoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                }
            );

            modelBuilder.Entity<TipoUsuario>(

                entity =>
                {
                    entity.HasKey(t => t.TipoUsuarioId);

                    entity.Property(t => t.DescricaoTipo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
                }
            );
        }
    }
}
