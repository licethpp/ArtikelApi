using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Artikelen.Migrations
{
    public partial class InitialArtikels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actiecodes",
                columns: table => new
                {
                    actiecodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    naam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    geldigVanDatum = table.Column<DateTime>(type: "date", nullable: false),
                    geldigTotDatum = table.Column<DateTime>(type: "date", nullable: false),
                    isEenmalig = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actiecodes", x => x.actiecodeId);
                });

            migrationBuilder.CreateTable(
                name: "artikelen",
                columns: table => new
                {
                    artikelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ean = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    naam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    beschrijving = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    prijs = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    gewichtInGram = table.Column<int>(type: "int", nullable: false),
                    bestelpeil = table.Column<int>(type: "int", nullable: false),
                    voorraad = table.Column<int>(type: "int", nullable: false),
                    minimumVoorraad = table.Column<int>(type: "int", nullable: false),
                    maximumVoorraad = table.Column<int>(type: "int", nullable: false),
                    levertijd = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    aantalBesteldLeverancier = table.Column<int>(type: "int", nullable: false),
                    maxAantalInMagazijnPLaats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.artikelId);
                });

            migrationBuilder.CreateTable(
                name: "bestellingsstatussen",
                columns: table => new
                {
                    bestellingsStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    naam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.bestellingsStatusId);
                });

            migrationBuilder.CreateTable(
                name: "betaalwijzes",
                columns: table => new
                {
                    betaalwijzeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    naam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_betaalwijzes", x => x.betaalwijzeId);
                });

            migrationBuilder.CreateTable(
                name: "categorieen",
                columns: table => new
                {
                    categorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    naam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    hoofdCategorieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.categorieId);
                    table.ForeignKey(
                        name: "fk_Categorieen_Categorieen1",
                        column: x => x.hoofdCategorieId,
                        principalTable: "categorieen",
                        principalColumn: "categorieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "eventmessages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    message = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventmessages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "eventwachtrijartikelen",
                columns: table => new
                {
                    artikelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    aantal = table.Column<int>(type: "int", nullable: false),
                    maxAantalInMagazijnPlaats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.artikelId);
                });

            migrationBuilder.CreateTable(
                name: "gebruikersaccounts",
                columns: table => new
                {
                    gebruikersAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    emailadres = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    paswoord = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    disabled = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gebruikersaccounts", x => x.gebruikersAccountId);
                });

            migrationBuilder.CreateTable(
                name: "personeelslidaccounts",
                columns: table => new
                {
                    personeelslidAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    emailadres = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    paswoord = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    disabled = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personeelslidaccounts", x => x.personeelslidAccountId);
                });

            migrationBuilder.CreateTable(
                name: "plaatsen",
                columns: table => new
                {
                    plaatsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    postcode = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    plaats = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.plaatsId);
                });

            migrationBuilder.CreateTable(
                name: "securitygroepen",
                columns: table => new
                {
                    securityGroepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    naam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.securityGroepId);
                });

            migrationBuilder.CreateTable(
                name: "uitgaandeleveringsstatussen",
                columns: table => new
                {
                    uitgaandeLeveringsStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    naam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uitgaandeLeveringsStatusId);
                });

            migrationBuilder.CreateTable(
                name: "artikelleveranciersinfolijnen",
                columns: table => new
                {
                    artikelLeveranciersInfoLijnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    artikelId = table.Column<int>(type: "int", nullable: false),
                    vraag = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    antwoord = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.artikelLeveranciersInfoLijnId, x.artikelId });
                    table.ForeignKey(
                        name: "fk_ArtikelLeveranciersInfoLijnen_Artikelen1",
                        column: x => x.artikelId,
                        principalTable: "artikelen",
                        principalColumn: "artikelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "magazijnplaatsen",
                columns: table => new
                {
                    magazijnPlaatsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    artikelId = table.Column<int>(type: "int", nullable: true),
                    rij = table.Column<string>(type: "char(1)", fixedLength: true, maxLength: 1, nullable: false),
                    rek = table.Column<int>(type: "int", nullable: false),
                    aantal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.magazijnPlaatsId);
                    table.ForeignKey(
                        name: "fk_MagazijnPlaatsen_Artikelen1",
                        column: x => x.artikelId,
                        principalTable: "artikelen",
                        principalColumn: "artikelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "veelgesteldevragenartikels",
                columns: table => new
                {
                    veelgesteldeVragenArtikelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    artikelId = table.Column<int>(type: "int", nullable: false),
                    vraag = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    antwoord = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veelgesteldevragenartikels", x => x.veelgesteldeVragenArtikelId);
                    table.ForeignKey(
                        name: "fk_VeelgesteldeVragenArtikels_Artikelen1",
                        column: x => x.artikelId,
                        principalTable: "artikelen",
                        principalColumn: "artikelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "artikelcategorieen",
                columns: table => new
                {
                    categorieId = table.Column<int>(type: "int", nullable: false),
                    artikelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.categorieId, x.artikelId });
                    table.ForeignKey(
                        name: "fk_ArtikelCategorieen_Artikelen1",
                        column: x => x.artikelId,
                        principalTable: "artikelen",
                        principalColumn: "artikelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ArtikelCategorieen_Categorieen1",
                        column: x => x.categorieId,
                        principalTable: "categorieen",
                        principalColumn: "categorieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chatgesprekken",
                columns: table => new
                {
                    chatgesprekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    gebruikersAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.chatgesprekId);
                    table.ForeignKey(
                        name: "fk_ChatGesprekken_GebruikersAccounts1",
                        column: x => x.gebruikersAccountId,
                        principalTable: "gebruikersaccounts",
                        principalColumn: "gebruikersAccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "wishlistitems",
                columns: table => new
                {
                    wishListItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    gebruikersAccountId = table.Column<int>(type: "int", nullable: false),
                    artikelId = table.Column<int>(type: "int", nullable: false),
                    aanvraagDatum = table.Column<DateTime>(type: "date", nullable: false),
                    aantal = table.Column<int>(type: "int", nullable: false, defaultValueSql: "'1'"),
                    emailGestuurdDatum = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.wishListItemId, x.gebruikersAccountId });
                    table.ForeignKey(
                        name: "fk_WishListItems_Artikelen1",
                        column: x => x.artikelId,
                        principalTable: "artikelen",
                        principalColumn: "artikelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_WishListItems_GebruikersAccounts1",
                        column: x => x.gebruikersAccountId,
                        principalTable: "gebruikersaccounts",
                        principalColumn: "gebruikersAccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personeelsleden",
                columns: table => new
                {
                    personeelslidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    voornaam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    familienaam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    inDienst = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    personeelslidAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.personeelslidId);
                    table.ForeignKey(
                        name: "fk_Personeelsleden_PersoneelslidAccounts1",
                        column: x => x.personeelslidAccountId,
                        principalTable: "personeelslidaccounts",
                        principalColumn: "personeelslidAccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "adressen",
                columns: table => new
                {
                    adresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    straat = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    huisNummer = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    bus = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    plaatsId = table.Column<int>(type: "int", nullable: false),
                    actief = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.adresId);
                    table.ForeignKey(
                        name: "fk_Adressen_Plaatsen",
                        column: x => x.plaatsId,
                        principalTable: "plaatsen",
                        principalColumn: "plaatsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "leveranciers",
                columns: table => new
                {
                    leveranciersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    naam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    btwNummer = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    straat = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    huisNummer = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    bus = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    plaatsId = table.Column<int>(type: "int", nullable: false),
                    familienaamContactpersoon = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    voornaamContactpersoon = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.leveranciersId);
                    table.ForeignKey(
                        name: "fk_Leveranciers_Plaatsen1",
                        column: x => x.plaatsId,
                        principalTable: "plaatsen",
                        principalColumn: "plaatsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chatgespreklijnen",
                columns: table => new
                {
                    chatgesprekLijnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    chatgesprekId = table.Column<int>(type: "int", nullable: false),
                    bericht = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    gebruikersAccountId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'0'"),
                    personeelslidAccountId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.chatgesprekLijnId);
                    table.ForeignKey(
                        name: "fk_ChatgesprekLijnen_ChatGesprekken1",
                        column: x => x.chatgesprekId,
                        principalTable: "chatgesprekken",
                        principalColumn: "chatgesprekId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ChatgesprekLijnen_GebruikersAccounts1",
                        column: x => x.gebruikersAccountId,
                        principalTable: "gebruikersaccounts",
                        principalColumn: "gebruikersAccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_ChatgesprekLijnen_PersoneelslidAccounts1",
                        column: x => x.personeelslidAccountId,
                        principalTable: "personeelslidaccounts",
                        principalColumn: "personeelslidAccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personeelslidsecuritygroepen",
                columns: table => new
                {
                    personeelslidId = table.Column<int>(type: "int", nullable: false),
                    securityGroepId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.personeelslidId, x.securityGroepId });
                    table.ForeignKey(
                        name: "fk_PersoneelslidSecurityGroepen_Personeelsleden1",
                        column: x => x.personeelslidId,
                        principalTable: "personeelsleden",
                        principalColumn: "personeelslidId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_PersoneelslidSecurityGroepen_SecurityGroepen1",
                        column: x => x.securityGroepId,
                        principalTable: "securitygroepen",
                        principalColumn: "securityGroepId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "klanten",
                columns: table => new
                {
                    klantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    facturatieAdresId = table.Column<int>(type: "int", nullable: false),
                    leveringsAdresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.klantId);
                    table.ForeignKey(
                        name: "fk_Klanten_Adressen1",
                        column: x => x.facturatieAdresId,
                        principalTable: "adressen",
                        principalColumn: "adresId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Klanten_Adressen2",
                        column: x => x.leveringsAdresId,
                        principalTable: "adressen",
                        principalColumn: "adresId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inkomendeleveringen",
                columns: table => new
                {
                    inkomendeLeveringsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    leveranciersId = table.Column<int>(type: "int", nullable: false),
                    leveringsbonNummer = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    leveringsbondatum = table.Column<DateTime>(type: "date", nullable: false),
                    leverDatum = table.Column<DateTime>(type: "date", nullable: false),
                    ontvangerPersoneelslidId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.inkomendeLeveringsId);
                    table.ForeignKey(
                        name: "fk_InkomendeLeveringen_Leveranciers1",
                        column: x => x.leveranciersId,
                        principalTable: "leveranciers",
                        principalColumn: "leveranciersId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_InkomendeLeveringen_Personeelsleden1",
                        column: x => x.ontvangerPersoneelslidId,
                        principalTable: "personeelsleden",
                        principalColumn: "personeelslidId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bestellingen",
                columns: table => new
                {
                    bestelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    besteldatum = table.Column<DateTime>(type: "datetime", nullable: false),
                    klantId = table.Column<int>(type: "int", nullable: false),
                    betaald = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    betalingscode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    betaalwijzeId = table.Column<int>(type: "int", nullable: false),
                    annulatie = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    annulatiedatum = table.Column<DateTime>(type: "date", nullable: true),
                    terugbetalingscode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    bestellingsStatusId = table.Column<int>(type: "int", nullable: false),
                    actiecodeGebruikt = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    bedrijfsnaam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    btwNummer = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    voornaam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    familienaam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    facturatieAdresId = table.Column<int>(type: "int", nullable: false),
                    leveringsAdresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.bestelId);
                    table.ForeignKey(
                        name: "fk_Bestellingen_Adressen1",
                        column: x => x.facturatieAdresId,
                        principalTable: "adressen",
                        principalColumn: "adresId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Bestellingen_Adressen2",
                        column: x => x.leveringsAdresId,
                        principalTable: "adressen",
                        principalColumn: "adresId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Bestellingen_BestellingsStatussen1",
                        column: x => x.bestellingsStatusId,
                        principalTable: "bestellingsstatussen",
                        principalColumn: "bestellingsStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Bestellingen_Betaalwijzes1",
                        column: x => x.betaalwijzeId,
                        principalTable: "betaalwijzes",
                        principalColumn: "betaalwijzeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Bestellingen_Klanten1",
                        column: x => x.klantId,
                        principalTable: "klanten",
                        principalColumn: "klantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "natuurlijkepersonen",
                columns: table => new
                {
                    klantId = table.Column<int>(type: "int", nullable: false),
                    voornaam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    familienaam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    gebruikersAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.klantId);
                    table.ForeignKey(
                        name: "fk_NatuurlijkePersonen_Gebruikersnamen1",
                        column: x => x.gebruikersAccountId,
                        principalTable: "gebruikersaccounts",
                        principalColumn: "gebruikersAccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_PrivateKlanten_Klanten1",
                        column: x => x.klantId,
                        principalTable: "klanten",
                        principalColumn: "klantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rechtspersonen",
                columns: table => new
                {
                    klantId = table.Column<int>(type: "int", nullable: false),
                    naam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    btwNummer = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.klantId);
                    table.ForeignKey(
                        name: "fk_Rechtspersonen_Klanten1",
                        column: x => x.klantId,
                        principalTable: "klanten",
                        principalColumn: "klantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inkomendeleveringslijnen",
                columns: table => new
                {
                    inkomendeLeveringsId = table.Column<int>(type: "int", nullable: false),
                    artikelId = table.Column<int>(type: "int", nullable: false),
                    magazijnPlaatsId = table.Column<int>(type: "int", nullable: false),
                    aantalGoedgekeurd = table.Column<int>(type: "int", nullable: false),
                    aantalTeruggestuurd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.inkomendeLeveringsId, x.artikelId, x.magazijnPlaatsId });
                    table.ForeignKey(
                        name: "fk_InkomendeLeveringsLijnen_Artikelen1",
                        column: x => x.artikelId,
                        principalTable: "artikelen",
                        principalColumn: "artikelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_InkomendeLeveringsLijnen_InkomendeLeveringen1",
                        column: x => x.inkomendeLeveringsId,
                        principalTable: "inkomendeleveringen",
                        principalColumn: "inkomendeLeveringsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_InkomendeLeveringsLijnen_MagazijnPlaatsen1",
                        column: x => x.magazijnPlaatsId,
                        principalTable: "magazijnplaatsen",
                        principalColumn: "magazijnPlaatsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bestellijnen",
                columns: table => new
                {
                    bestellijnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    bestelId = table.Column<int>(type: "int", nullable: false),
                    artikelId = table.Column<int>(type: "int", nullable: false),
                    aantalBesteld = table.Column<int>(type: "int", nullable: false),
                    aantalGeannuleerd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.bestellijnId);
                    table.ForeignKey(
                        name: "fk_Bestellijnen_Artikelen1",
                        column: x => x.artikelId,
                        principalTable: "artikelen",
                        principalColumn: "artikelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Bestellijnen_Bestellingen1",
                        column: x => x.bestelId,
                        principalTable: "bestellingen",
                        principalColumn: "bestelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "uitgaandeleveringen",
                columns: table => new
                {
                    uitgaandeLeveringsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    bestelId = table.Column<int>(type: "int", nullable: false),
                    vertrekDatum = table.Column<DateTime>(type: "date", nullable: false),
                    aankomstDatum = table.Column<DateTime>(type: "date", nullable: true),
                    trackingcode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    klantId = table.Column<int>(type: "int", nullable: false),
                    uitgaandeLeveringsStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.uitgaandeLeveringsId);
                    table.ForeignKey(
                        name: "fk_UitgaandeLeveringen_Bestellingen1",
                        column: x => x.bestelId,
                        principalTable: "bestellingen",
                        principalColumn: "bestelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_UitgaandeLeveringen_Klanten1",
                        column: x => x.klantId,
                        principalTable: "klanten",
                        principalColumn: "klantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_UitgaandeLeveringen_UitgaandeLeveringsStatussn1",
                        column: x => x.uitgaandeLeveringsStatusId,
                        principalTable: "uitgaandeleveringsstatussen",
                        principalColumn: "uitgaandeLeveringsStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contactpersonen",
                columns: table => new
                {
                    contactpersoonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    voornaam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    familienaam = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    functie = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    klantId = table.Column<int>(type: "int", nullable: false),
                    gebruikersAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.contactpersoonId);
                    table.ForeignKey(
                        name: "fk_Contactpersonen_GebruikersAccounts1",
                        column: x => x.gebruikersAccountId,
                        principalTable: "gebruikersaccounts",
                        principalColumn: "gebruikersAccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Contactpersonen_Rechtspersonen1",
                        column: x => x.klantId,
                        principalTable: "rechtspersonen",
                        principalColumn: "klantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "klantenreviews",
                columns: table => new
                {
                    klantenReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nickname = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    commentaar = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    datum = table.Column<DateTime>(type: "date", nullable: false),
                    bestellijnId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_klantenreviews", x => x.klantenReviewId);
                    table.ForeignKey(
                        name: "fk_KlantenReviews_Bestellijnen1",
                        column: x => x.bestellijnId,
                        principalTable: "bestellijnen",
                        principalColumn: "bestellijnId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fk_Adressen_Plaatsen_idx",
                table: "adressen",
                column: "plaatsId");

            migrationBuilder.CreateIndex(
                name: "fk_ArtikelCategorieen_Artikelen1_idx",
                table: "artikelcategorieen",
                column: "artikelId");

            migrationBuilder.CreateIndex(
                name: "ean_UNIQUE",
                table: "artikelen",
                column: "ean",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_ArtikelLeveranciersInfoLijnen_Artikelen1_idx",
                table: "artikelleveranciersinfolijnen",
                column: "artikelId");

            migrationBuilder.CreateIndex(
                name: "fk_Bestellijnen_Artikelen1_idx",
                table: "bestellijnen",
                column: "artikelId");

            migrationBuilder.CreateIndex(
                name: "fk_Bestellijnen_Bestellingen1_idx",
                table: "bestellijnen",
                column: "bestelId");

            migrationBuilder.CreateIndex(
                name: "fk_Bestellingen_Adressen1_idx",
                table: "bestellingen",
                column: "facturatieAdresId");

            migrationBuilder.CreateIndex(
                name: "fk_Bestellingen_Adressen2_idx",
                table: "bestellingen",
                column: "leveringsAdresId");

            migrationBuilder.CreateIndex(
                name: "fk_Bestellingen_BestellingsStatussen1_idx",
                table: "bestellingen",
                column: "bestellingsStatusId");

            migrationBuilder.CreateIndex(
                name: "fk_Bestellingen_Betaalwijzes1_idx",
                table: "bestellingen",
                column: "betaalwijzeId");

            migrationBuilder.CreateIndex(
                name: "fk_Bestellingen_Klanten1_idx",
                table: "bestellingen",
                column: "klantId");

            migrationBuilder.CreateIndex(
                name: "fk_Categorieen_Categorieen1_idx",
                table: "categorieen",
                column: "hoofdCategorieId");

            migrationBuilder.CreateIndex(
                name: "fk_ChatGesprekken_GebruikersAccounts1_idx",
                table: "chatgesprekken",
                column: "gebruikersAccountId");

            migrationBuilder.CreateIndex(
                name: "fk_ChatgesprekLijnen_ChatGesprekken1_idx",
                table: "chatgespreklijnen",
                column: "chatgesprekId");

            migrationBuilder.CreateIndex(
                name: "fk_ChatgesprekLijnen_GebruikersAccounts1_idx",
                table: "chatgespreklijnen",
                column: "gebruikersAccountId");

            migrationBuilder.CreateIndex(
                name: "fk_ChatgesprekLijnen_PersoneelslidAccounts1_idx",
                table: "chatgespreklijnen",
                column: "personeelslidAccountId");

            migrationBuilder.CreateIndex(
                name: "fk_Contactpersonen_GebruikersAccounts_idx",
                table: "contactpersonen",
                column: "gebruikersAccountId");

            migrationBuilder.CreateIndex(
                name: "fk_Contactpersonen_Rechtspersonen1_idx",
                table: "contactpersonen",
                column: "klantId");

            migrationBuilder.CreateIndex(
                name: "gebrukersnaam_UNIQUE",
                table: "gebruikersaccounts",
                column: "emailadres",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_InkomendeLeveringen_Leveranciers1",
                table: "inkomendeleveringen",
                column: "leveranciersId");

            migrationBuilder.CreateIndex(
                name: "fk_InkomendeLeveringen_Personeelsleden1_idx",
                table: "inkomendeleveringen",
                column: "ontvangerPersoneelslidId");

            migrationBuilder.CreateIndex(
                name: "fk_InkomendeLeveringsLijnen_Artikelen1_idx",
                table: "inkomendeleveringslijnen",
                column: "artikelId");

            migrationBuilder.CreateIndex(
                name: "fk_InkomendeLeveringsLijnen_MagazijnPlaatsen1_idx",
                table: "inkomendeleveringslijnen",
                column: "magazijnPlaatsId");

            migrationBuilder.CreateIndex(
                name: "fk_Klanten_Adressen1_idx",
                table: "klanten",
                column: "facturatieAdresId");

            migrationBuilder.CreateIndex(
                name: "fk_Klanten_Adressen2_idx",
                table: "klanten",
                column: "leveringsAdresId");

            migrationBuilder.CreateIndex(
                name: "fk_KlantenReviews_Bestellijnen1_idx",
                table: "klantenreviews",
                column: "bestellijnId");

            migrationBuilder.CreateIndex(
                name: "fk_Leveranciers_Plaatsen1_idx",
                table: "leveranciers",
                column: "plaatsId");

            migrationBuilder.CreateIndex(
                name: "fk_MagazijnPlaatsen_Artikelen1_idx",
                table: "magazijnplaatsen",
                column: "artikelId");

            migrationBuilder.CreateIndex(
                name: "uinx_rijrek",
                table: "magazijnplaatsen",
                columns: new[] { "rij", "rek" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_NatuurlijkePersonen_gebruikersAccountId_idx",
                table: "natuurlijkepersonen",
                column: "gebruikersAccountId");

            migrationBuilder.CreateIndex(
                name: "fk_PrivateKlanten_Klanten1_idx",
                table: "natuurlijkepersonen",
                column: "klantId");

            migrationBuilder.CreateIndex(
                name: "fk_Personeelsleden_PersoneelslidAccounts1_idx",
                table: "personeelsleden",
                column: "personeelslidAccountId");

            migrationBuilder.CreateIndex(
                name: "emailadres_UNIQUE",
                table: "personeelslidaccounts",
                column: "emailadres",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_PersoneelslidSecurityGroepen_SecurityGroepen1_idx",
                table: "personeelslidsecuritygroepen",
                column: "securityGroepId");

            migrationBuilder.CreateIndex(
                name: "fk_UitgaandeLeveringen_Bestellingen1_idx",
                table: "uitgaandeleveringen",
                column: "bestelId");

            migrationBuilder.CreateIndex(
                name: "fk_UitgaandeLeveringen_Klanten1_idx",
                table: "uitgaandeleveringen",
                column: "klantId");

            migrationBuilder.CreateIndex(
                name: "fk_UitgaandeLeveringen_UitgaandeLeveringsStatussn1_idx",
                table: "uitgaandeleveringen",
                column: "uitgaandeLeveringsStatusId");

            migrationBuilder.CreateIndex(
                name: "fk_VeelgesteldeVragenArtikels_Artikelen1_idx",
                table: "veelgesteldevragenartikels",
                column: "artikelId");

            migrationBuilder.CreateIndex(
                name: "fk_WishListItems_Artikelen1_idx",
                table: "wishlistitems",
                column: "artikelId");

            migrationBuilder.CreateIndex(
                name: "fk_WishListItems_GebruikersAccounts1_idx",
                table: "wishlistitems",
                column: "gebruikersAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actiecodes");

            migrationBuilder.DropTable(
                name: "artikelcategorieen");

            migrationBuilder.DropTable(
                name: "artikelleveranciersinfolijnen");

            migrationBuilder.DropTable(
                name: "chatgespreklijnen");

            migrationBuilder.DropTable(
                name: "contactpersonen");

            migrationBuilder.DropTable(
                name: "eventmessages");

            migrationBuilder.DropTable(
                name: "eventwachtrijartikelen");

            migrationBuilder.DropTable(
                name: "inkomendeleveringslijnen");

            migrationBuilder.DropTable(
                name: "klantenreviews");

            migrationBuilder.DropTable(
                name: "natuurlijkepersonen");

            migrationBuilder.DropTable(
                name: "personeelslidsecuritygroepen");

            migrationBuilder.DropTable(
                name: "uitgaandeleveringen");

            migrationBuilder.DropTable(
                name: "veelgesteldevragenartikels");

            migrationBuilder.DropTable(
                name: "wishlistitems");

            migrationBuilder.DropTable(
                name: "categorieen");

            migrationBuilder.DropTable(
                name: "chatgesprekken");

            migrationBuilder.DropTable(
                name: "rechtspersonen");

            migrationBuilder.DropTable(
                name: "inkomendeleveringen");

            migrationBuilder.DropTable(
                name: "magazijnplaatsen");

            migrationBuilder.DropTable(
                name: "bestellijnen");

            migrationBuilder.DropTable(
                name: "securitygroepen");

            migrationBuilder.DropTable(
                name: "uitgaandeleveringsstatussen");

            migrationBuilder.DropTable(
                name: "gebruikersaccounts");

            migrationBuilder.DropTable(
                name: "leveranciers");

            migrationBuilder.DropTable(
                name: "personeelsleden");

            migrationBuilder.DropTable(
                name: "artikelen");

            migrationBuilder.DropTable(
                name: "bestellingen");

            migrationBuilder.DropTable(
                name: "personeelslidaccounts");

            migrationBuilder.DropTable(
                name: "bestellingsstatussen");

            migrationBuilder.DropTable(
                name: "betaalwijzes");

            migrationBuilder.DropTable(
                name: "klanten");

            migrationBuilder.DropTable(
                name: "adressen");

            migrationBuilder.DropTable(
                name: "plaatsen");
        }
    }
}
