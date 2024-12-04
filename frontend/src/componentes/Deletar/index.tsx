function Deletar() {
    return ( 
        <div className="container">
        <h2>Excluir Arma</h2>
        <form className="crud-form">
          <label htmlFor="delete-id">ID ou Nome:</label>
          <input
            type="text"
            id="delete-id"
            placeholder="Identifique o registro"
          />

          <button type="button" className="delete-button">Excluir Registro</button>
        </form> 
        </div>
        
    );
  }
  
  export default Deletar;



  