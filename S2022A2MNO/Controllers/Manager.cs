// ************************************************************************************
// WEB524 Project Template V1 2224 == ead802e1-314a-4338-bdb2-c806ee1a5f11
// Do not change or remove the line above.
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

using AutoMapper;
using S2022A2MNO.EntityModels;
using S2022A2MNO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S2022A2MNO.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();
                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Invoice, InvoiceBaseViewModel>();
                cfg.CreateMap<Invoice, InvoiceWithDetailViewModel>();
            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().
        public IEnumerable<TrackBaseViewModel> TrackGetAll() {
            var query = ds.Tracks.OrderBy(q => q.Name);

            return mapper.Map<IEnumerable<Track>, 
                IEnumerable<TrackBaseViewModel>>(query);
        }
        public IEnumerable<TrackBaseViewModel> TrackGetAllRockMetal() {
            var query = ds.Tracks.Where(q => q.GenreId == 1 || q.GenreId == 3)
                                 .OrderBy(q => q.Name).ThenBy(q => q.Composer);

            return mapper.Map<IEnumerable<Track>,
                IEnumerable<TrackBaseViewModel>>(query);
        }
        public IEnumerable<TrackBaseViewModel> TrackGetAllTylerVallance() {
            var query = ds.Tracks.Where(q => q.Composer.Contains("Steven Tyler")
                                             && q.Composer.Contains("Jim Vallance"))
                                 .OrderBy(q => q.Composer).ThenBy(q => q.Name);
            
            return mapper.Map<IEnumerable<Track>,
                IEnumerable<TrackBaseViewModel>>(query);
        }
        public IEnumerable<TrackBaseViewModel> TrackGetAllTop50Longest() {
            var query = ds.Tracks.OrderByDescending(q => q.Milliseconds).Take(50);

            return mapper.Map<IEnumerable<Track>,
                IEnumerable<TrackBaseViewModel>>(query);
        }
        public IEnumerable<TrackBaseViewModel> TrackGetAllTop50Smallest() {
            var query = ds.Tracks.OrderBy(q => q.Bytes).Take(50);

            return mapper.Map<IEnumerable<Track>,
                IEnumerable<TrackBaseViewModel>>(query);
        }
        public IEnumerable<InvoiceBaseViewModel> InvoiceGetAll() {
            var query = ds.Invoices.OrderByDescending(q => q.InvoiceDate);

            return mapper.Map<IEnumerable<Invoice>,
                IEnumerable<InvoiceBaseViewModel>>(query);
        }
        public InvoiceBaseViewModel InvoiceGetById(int? id) {
            var query = ds.Invoices.Find(id);

            if (query == null) return null;

            return mapper.Map<Invoice, InvoiceBaseViewModel>(query);
        }
        public InvoiceWithDetailViewModel InvoiceGetByIdWithDetail(int? id) {
            var query = ds.Invoices.Include("Customer.Employee")
                .SingleOrDefault(q => q.InvoiceId == id);

            if (query == null) return null;

            return mapper.Map<Invoice, InvoiceWithDetailViewModel>(query);
        }
    }
}