using System;
using Supabase.Postgrest;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase;

public static class SupabaseClient
{
    public static Supabase.Client Client { get; private set; }

    public static bool IsInitialized { get; private set; } = false;

    public static async Task Initialize()
    {
        var options = new Supabase.SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true
        };

        Client = new Supabase.Client(
            "https://bgpquoxpnxcrnhzezaaf.supabase.co",
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImJncHF1b3hwbnhjcm5oemV6YWFmIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDM4NDIyMTgsImV4cCI6MjA1OTQxODIxOH0.zRX0_9aw1UKvU2Di9b7wjzMdwNOuxLygjmKEpAHC7TU",
            options);

        await Client.InitializeAsync();

        IsInitialized = true;
    }
}

