flowchart LR
    
    subgraph FRONTEND [UI5 Frontend]
        UI5_Views[UI5 Views]
        UI5_Controllers[UI5 Controllers]
       
        
    end

    subgraph API [Backend API Layer]
        REST[REST API]

    end

    subgraph BLL [Backend BLL]
        Interfaces[Interfaces]
        Services[Services]
       
    end

    subgraph DAL [Backend DAL]
        InterfacesDAL[InterfacesDAL]
        Repositories[Repositories]
    end

    subgraph DB [DB]
        Database[(Database)]
    end
    
    subgraph Agent [n8n]
        n8n[n8n agent]
    end

    subgraph LLM[Gemini]
        Gemini[Gemini]
    end

    UI5_Views --> UI5_Controllers --> n8n --> Gemini --> n8n --> UI5_Controllers --> UI5_Views
    UI5_Views --> UI5_Controllers --> REST --> Interfaces --> Services --> InterfacesDAL --> Repositories --> DB --> Repositories --> Services --> REST --> UI5_Controllers --> UI5_Views
    
   
