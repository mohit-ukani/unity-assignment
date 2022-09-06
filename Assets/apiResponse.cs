


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using System.Collections.Generic;

public class Data
    {
        public List<Slideshow> slideshow { get; set; }
    }

    public class PlaceholderAliases
    {
    }

    public class ResponseChannels
    {
        public string voice { get; set; }
        public string frames { get; set; }
        public string shapes { get; set; }
    }

    public class Root1
    {
        public bool hide_in_customer_history { get; set; }
        public object registered_entities { get; set; }
        public string whiteboard_template { get; set; }
        public string customer_state { get; set; }
        public PlaceholderAliases placeholder_aliases { get; set; }
        public bool show_feedback { get; set; }
        public ToStateFunction to_state_function { get; set; }
        public string placeholder { get; set; }
        public bool show_in_history { get; set; }
        public Data data { get; set; }
        public bool overwrite_whiteboard { get; set; }
        public string start_timestamp { get; set; }
        public string console { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public ResponseChannels response_channels { get; set; }
        public string whiteboard { get; set; }
        public StateOptions state_options { get; set; }
        public string response_id { get; set; }
        public string whiteboard_title { get; set; }
        public string timestamp { get; set; }
        public bool maintain_whiteboard { get; set; }
        public int wait { get; set; }
        public string type { get; set; }
        public object options { get; set; }
        public string engagement_id { get; set; }
    }

    public class Slideshow
    {
        public string image { get; set; }
        public string caption { get; set; }
    }

    public class StateOptions
    {
        public string cs_top_three { get; set; }
        public string cs_must_have { get; set; }
        public string cs_enquiry { get; set; }
        public string cs_mt1 { get; set; }
        public string cs_mt2 { get; set; }
        public string cs_mt3 { get; set; }
    }

    public class ToStateFunction
    {
        public string function { get; set; }
    }



