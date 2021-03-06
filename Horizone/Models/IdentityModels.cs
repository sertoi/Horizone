﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Horizone.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }   
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Horizone", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
        }
        //pour tous
        public DbSet<Language> Languages { get; set; }
        public DbSet<LinkAndPress> LinkAndPresses { get; set; }
        public DbSet<AboutProject> AboutProjets { get; set; }
        public DbSet<ImageProject> ImageProjets { get; set; }

        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<ImageMap> ImageMaps { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<SearchResult> SearchResults { get; set; }

        //Gestion Utilisateur et équipe
        public DbSet<Client> Clients { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Collaboration> Collaborations { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<PartnerAndRelation> PartnerAndRelations { get; set; }
        public DbSet<ImagePartner> ImagePartners { get; set; }
        public DbSet<ImageCollaboration> ImageCollaborations { get; set; }

        //Visual Aid
        public DbSet<VisualAid> VisualAids { get; set; }

        //News and Activity
        public DbSet<Comment> Comments { get; set; }
        public DbSet<News> Newses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<ImageNews> ImageNews { get; set; }
        public DbSet<Activity> Activitys { get; set; }

        //Dictionaire
        public DbSet<TochLanguage> TochLanguages { get; set; }
        public DbSet<DictionaryTocharian> DictionaryTocharians { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Number>Numbers { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<TenseAndAspect> TenseAndAspects { get; set; }
        public DbSet<Valency> Valencies { get; set; }
        public DbSet<Voice> Voices { get; set; }
        public DbSet<Mood> Moods { get; set; }
        public DbSet<WordClass> WordClasses { get; set; }
        public DbSet<WordSubClass> WordSubClasses { get; set; }
        public DbSet<AbbreviationDictionary> AbbreviationDictionaries { get; set; }
        public DbSet<ReverseDictionary> ReverseDictionaries { get; set; }
        public DbSet<Verb> Verbs { get; set; }
        public DbSet<NounAdjective> NounAdjectives { get; set; }
        public DbSet<Pronoun> Pronouns { get; set; }
        public DbSet<OtherWord> OtherWords { get; set; }

        //Manuscript
        public DbSet<Catalogie> Catalogies { get; set; }
        public DbSet<ImageManuscript> ImageManuscripts { get; set; }
        public DbSet<Manuscript> Manuscripts { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<DescriptionManuscript> DescriptionManuscripts { get; set; }
        public DbSet<RemarkAdd> RemarkAdds { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Ruling> Rulings { get; set; }
        public DbSet<RulingColor> RulingColors { get; set; }
        public DbSet<RulingDetail> RulingDetails { get; set; }
        public DbSet<PaperColor> PaperColors { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<WritingTool> WritingTools { get; set; }
        public DbSet<AlignmentType> AlignmentTypes { get; set; }
        public DbSet<Script> Scripts { get; set; }
        public DbSet<ScriptType> ScriptTypes { get; set; }
        public DbSet<ScriptAdd> ScriptAdds { get; set; }
        public DbSet<LanguageStage> LanguageStages { get; set; }
        public DbSet<LanguageDetail> LanguageDetails { get; set; }
        public DbSet<GenderManuscript> GenderManuscripts { get; set; }
        public DbSet<SubGenderManuscript> SubGenderManuscripts { get; set; }
        public DbSet<Metric> Metrics { get; set; }
        public DbSet<AnalyseMaterial> AnalyseMaterials { get; set; }
        public DbSet<ImageUV> ImageUVs { get; set; }
        public DbSet<ImageAnalyse> ImageAnalyses { get; set; }
        //Analyse Macroscopic
        public DbSet<AnalyseMacroscopic> AnalyseMacroscopics { get; set; }
        public DbSet<TransmittedLight> TransmittedLights { get; set; }
        public DbSet<Restore> Restores { get; set; }
        public DbSet<ManufaturingDefect> ManufaturingDefects { get; set; }
        public DbSet<PreparationPaperBeforeUsing> PreparationPaperBeforeUsings { get; set; }
        public DbSet<Drying> Dryings { get; set; }
        public DbSet<ChainLinesVisibility> ChainLinesVisibilitys { get; set; }
        public DbSet<LaidLinesRegularity> LaidLinesRegularitys { get; set; }
        public DbSet<FiberDirection> FiberDirections { get; set; }
        public DbSet<SieveMark> SieveMarks { get; set; }
        public DbSet<FiberDistribution> FiberDistributions { get; set; }
      
        //TochPhrase and TochStory
        public DbSet<TochPhrase> TochPhrases { get; set; }
        public DbSet<TochStory> TochStorys { get; set; }
        public DbSet<NamePlace> NamePlaces { get; set; }
        public DbSet<ThemeStory> ThemeStorys { get; set; }
        public DbSet<SourceStory> SourceStorys { get; set; }
        public DbSet<ProperNoun> ProperNouns { get; set; }

        //Reference
        public DbSet<Bibliography> Bibliographys { get; set; }
        public DbSet<Abreviation> Abreviations { get; set; }
        public DbSet<ImageBook> ImageBooks { get; set; }

    }
}