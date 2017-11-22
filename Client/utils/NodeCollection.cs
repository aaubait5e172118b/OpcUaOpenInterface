using System;
using System.Collections.Generic;
using Opc.Ua;
using Opc.Ua.Client;

namespace Client
{
    public class NodeCollection
    {
        public ReferenceDescriptionCollection Collection { get; set; }
        public ExpandedNodeId ParentId { get; set; }

        public NodeCollection(ReferenceDescriptionCollection collection, ExpandedNodeId parentId)
        {
            Collection = collection;
            ParentId = parentId;
        }
    }
}