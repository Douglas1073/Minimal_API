function Atualizar() {
    return (
        <section className="container crud-section-atualizar">
        <h2>Atualizar Arma</h2>
        <form className="crud-form">
          <label htmlFor="put-id">ID ou Nome:</label>
          <input type="text" id="put-id" placeholder="Identifique o registro" />
          <label htmlFor="put-nome">Nome:</label>
          <input
            type="text"
            id="put-nome"
            placeholder="Digite o nome da arma"
          />
          <div className="alterações">
            <button type="button">Salvar Alterações</button>
          </div>
        </form>
      </section>
    );
  }
  
  export default Atualizar;