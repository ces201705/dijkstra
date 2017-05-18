using Oceanic.DAL;
using Oceanic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oceanic.Controllers
{
    public class ServiceController : Controller
    {
        public ActionResult GetSegments()
        {
            //Entities entities = new Entities();
            //List<Location> locations = entities.Locations.ToList();
            //List<Segment> segments = entities.Segments.ToList();

            Entities context = new Entities();

            List<SegmentItem> segmentItems = (from s in context.Segments
                                              join sl in context.Locations on s.StartLocationId equals sl.Id
                                              join el in context.Locations on s.EndLocationId equals el.Id
                                              select new SegmentItem
                                              {
                                                  SourceLocationName = sl.Name,
                                                  EndLocationName = el.Name,
                                                  Price = (decimal)s.Price,
                                                  Time = (decimal)s.Time
                                              }).ToList();



            //List<ColumnMapping> columnMappingList = (from m in ScriptingDbModel.Instance.Mappings
            //                                         join fm in ScriptingDbModel.Instance.FieldMappings on m.MappingID equals fm.MappingFK
            //                                         join p in ScriptingDbModel.Instance.Ports on fm.SourcePortFK equals p.PortID
            //                                         join srcTable in ScriptingDbModel.Instance.Tables on m.PrimarySourceTableFK equals srcTable.TableID
            //                                         join srcTableLayer in ScriptingDbModel.Instance.DWLayers on srcTable.DWLayerFK equals srcTableLayer.DWLayerID
            //                                         join srcColumn in ScriptingDbModel.Instance.Columns on p.ColumnFK equals srcColumn.ColumnID
            //                                         join dstTable in ScriptingDbModel.Instance.Tables on m.PrimaryDestinationTableFK equals dstTable.TableID
            //                                         join dstTableLayer in ScriptingDbModel.Instance.DWLayers on dstTable.DWLayerFK equals dstTableLayer.DWLayerID
            //                                         join dstColumn in ScriptingDbModel.Instance.Columns on fm.DestinationColumnFK equals dstColumn.ColumnID
            //                                         where dstTable.TableName == dstTableName
            //                                         select new ColumnMapping
            //                                         {
            //                                             ProductionSystem = srcTable.ProduktionsSystem,
            //                                             SrcLayer = srcTableLayer.DWLayerName,
            //                                             SrcTable = srcTable.TableName,
            //                                             SrcColumn = srcColumn.ColumnName,
            //                                             DstLayer = dstTableLayer.DWLayerName,
            //                                             DstTable = dstTable.TableName,
            //                                             DstColumn = dstColumn.ColumnName,
            //                                         }).ToList();
            //return (columnMappingList);


            //List<SegmentItem> segmentItems = new List<SegmentItem>();

            //segmentItems.Add(new SegmentItem() { SourceLocationName = "Warszawa", EndLocationName = "Serock", Time = 10, Price = 35 });
            //segmentItems.Add(new SegmentItem() { SourceLocationName = "Zakopane", EndLocationName = "Katowice", Time = 2, Price = 14 });
            //segmentItems.Add(new SegmentItem() { SourceLocationName = "Poznań", EndLocationName = "Szczecin", Time = 32, Price = 24 });
            //segmentItems.Add(new SegmentItem() { SourceLocationName = "Warszawa", EndLocationName = "Pisz", Time = 24, Price = 44 });

            return Json(segmentItems, JsonRequestBehavior.AllowGet);
        }
    }
}