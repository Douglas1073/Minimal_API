function Cadastro() {
    return (
        <section className=" container crud-section-cadastro">
        <h2>Cadastrar Nova Arma</h2>
        <form className="crud-form">
          <div className="armas-form">
            <label htmlFor="post-nome">Nome:</label>
            <input
              type="text"
              id="post-nome"
              placeholder="Digite o nome da arma"
            />

            <label htmlFor="post-calibre">Calibre:</label>
            <input type="text" id="post-calibre" placeholder="Ex: 9mm, .38" />

            <label htmlFor="post-comprimento">Comprimento Total (cm):</label>
            <input type="number" id="post-comprimento" placeholder="Ex: 85" />

            <label htmlFor="post-capacidade">Capacidade do Carregador:</label>
            <input type="number" id="post-capacidade" placeholder="Ex: 17" />

            <label htmlFor="post-peso">Peso (kg):</label>
            <input
              type="number"
              step="0.1"
              id="post-peso"
              placeholder="Ex: 0.8"
            />

            <label htmlFor="post-fabricante">Fabricante:</label>
            <input
              type="text"
              id="post-fabricante"
              placeholder="Ex: Glock, Taurus"
            />

            <label>Tipo:</label>
            <select id="post-tipo">
              <option>Pistola</option>
              <option>Revólver</option>
              <option>Espingarda</option>
              <option>Outra</option>
            </select>

            <label htmlFor="post-data">Data de Fabricação:</label>
            <input type="date" id="post-data" />
            <div className="cadastro">
              <button type="button">Cadastrar</button>
            </div>
          </div>
        </form>
      </section>
    );
  }
  
  export default Cadastro;