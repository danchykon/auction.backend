﻿// <auto-generated />
using System;
using Auction.Domain.Enums;
using Auction.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Auction.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    partial class AuctionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auction_state", new[] { "scheduled", "opened", "closed" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "lot_state", new[] { "scheduled", "bids_are_opened", "bids_are_closed" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Auction.Domain.Entities.AuctionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Avatar")
                        .HasColumnType("text")
                        .HasColumnName("avatar");

                    b.Property<DateTimeOffset>("ClosesAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("closes_at");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTimeOffset>("OpensAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("opens_at");

                    b.Property<AuctionState>("State")
                        .HasColumnType("auction_state")
                        .HasColumnName("state");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_auctions");

                    b.HasIndex("State")
                        .HasDatabaseName("ix_auctions_state");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("State"), "hash");

                    b.HasIndex("Title")
                        .HasDatabaseName("ix_auctions_title");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Title"), "btree");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_auctions_user_id");

                    b.ToTable("auctions", (string)null);
                });

            modelBuilder.Entity("Auction.Domain.Entities.BidEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("LotEntityId")
                        .HasColumnType("uuid")
                        .HasColumnName("lot_entity_id");

                    b.Property<Guid>("LotId")
                        .HasColumnType("uuid")
                        .HasColumnName("lot_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_bids");

                    b.HasIndex("LotEntityId")
                        .HasDatabaseName("ix_bids_lot_entity_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_bids_user_id");

                    b.ToTable("bids", (string)null);
                });

            modelBuilder.Entity("Auction.Domain.Entities.LotEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AuctionId")
                        .HasColumnType("uuid")
                        .HasColumnName("auction_id");

                    b.Property<string>("Avatar")
                        .HasColumnType("text")
                        .HasColumnName("avatar");

                    b.Property<DateTimeOffset>("ClosesAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("closes_at");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<decimal>("MinPriceStepSize")
                        .HasColumnType("numeric")
                        .HasColumnName("min_price_step_size");

                    b.Property<DateTimeOffset>("OpensAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("opens_at");

                    b.Property<decimal>("StartPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("start_price");

                    b.Property<LotState>("State")
                        .HasColumnType("lot_state")
                        .HasColumnName("state");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_lots");

                    b.HasIndex("AuctionId")
                        .HasDatabaseName("ix_lots_auction_id");

                    b.HasIndex("State")
                        .HasDatabaseName("ix_lots_state");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("State"), "hash");

                    b.HasIndex("Title")
                        .HasDatabaseName("ix_lots_title");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("Title"), "btree");

                    b.ToTable("lots", (string)null);
                });

            modelBuilder.Entity("Auction.Domain.Entities.MessageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AuctionId")
                        .HasColumnType("uuid")
                        .HasColumnName("auction_id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_messages");

                    b.HasIndex("AuctionId")
                        .HasDatabaseName("ix_messages_auction_id");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("ix_messages_created_at");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("CreatedAt"), "btree");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_messages_user_id");

                    b.ToTable("messages", (string)null);
                });

            modelBuilder.Entity("Auction.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Avatar")
                        .HasColumnType("text")
                        .HasColumnName("avatar");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Auction.Infrastructure.Entities.CentrifugoOutboxEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("method");

                    b.Property<int>("Partition")
                        .HasColumnType("integer")
                        .HasColumnName("partition");

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("payload");

                    b.HasKey("Id")
                        .HasName("pk_centrifugo_outbox");

                    b.ToTable("centrifugo_outbox", null, t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Auction.Domain.Entities.AuctionEntity", b =>
                {
                    b.HasOne("Auction.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_auctions_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Auction.Domain.Entities.BidEntity", b =>
                {
                    b.HasOne("Auction.Domain.Entities.LotEntity", null)
                        .WithMany("Bids")
                        .HasForeignKey("LotEntityId")
                        .HasConstraintName("fk_bids_lots_lot_entity_id");

                    b.HasOne("Auction.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bids_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Auction.Domain.Entities.LotEntity", b =>
                {
                    b.HasOne("Auction.Domain.Entities.AuctionEntity", "Auction")
                        .WithMany("Lots")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_lots_auctions_auction_id");

                    b.Navigation("Auction");
                });

            modelBuilder.Entity("Auction.Domain.Entities.MessageEntity", b =>
                {
                    b.HasOne("Auction.Domain.Entities.AuctionEntity", "Auction")
                        .WithMany()
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_messages_auctions_auction_id");

                    b.HasOne("Auction.Domain.Entities.UserEntity", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_messages_users_user_id");

                    b.Navigation("Auction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Auction.Domain.Entities.AuctionEntity", b =>
                {
                    b.Navigation("Lots");
                });

            modelBuilder.Entity("Auction.Domain.Entities.LotEntity", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("Auction.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
