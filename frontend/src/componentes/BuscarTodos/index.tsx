import { useEffect, useState } from "react";
import axios from "axios";
import { Armas } from "../../types/armas";

function BuscarTodos() {
  const [armas, setArmas] = useState<Armas>();

  useEffect(() => {
    axios.get("http://localhost:5161/armas").then((response) => {
      const data = response.data as Armas;
      console.log(data);
      setArmas(data);
    });
  }, [armas]);

  return (
    <section className="container crud-section">
      <h2>Buscar Arma</h2>
      <form className="crud-form">
        <label htmlFor="nome">Nome:</label>
        <input type="text" id="nome" placeholder="Digite o nome da arma" />

        <label htmlFor="Id">Id:</label>
        <input type="text" id="Id" placeholder="Ex: 10, 11, 12, 13, 14, 15" />
      </form>
      <div className="tabela">
        <ol>
          <li>Nome: Glock G17</li>
          <li>Calibre: 9mm</li>
          <li>Comprimento: 20</li>
          <li>Capacidade: 17</li>
          <li>Peso: 0.8</li>
          <li>Fabricante: Glock</li>
          <li>Tipo: Pistol</li>
          <li>Data de Fabricação: 2021-10-01</li>
        </ol>
        <button type="button">Buscar</button>
      </div>
    </section>
  );
}

export default BuscarTodos;
