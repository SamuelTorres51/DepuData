const elList = document.getElementById("list");
const elStatus = document.getElementById("status");
const elUpdatedAt = document.getElementById("updatedAt");
const elFilter = document.getElementById("filter");
const elReload = document.getElementById("reload");

const currency = new Intl.NumberFormat("pt-BR", { style: "currency", currency: "BRL" });

let allItems = [];
let chart;

function setStatus(text) {
  elStatus.textContent = text;
}

function escapeHtml(s) {
  return String(s)
    .replaceAll("&", "&amp;")
    .replaceAll("<", "&lt;")
    .replaceAll(">", "&gt;")
    .replaceAll('"', "&quot;")
    .replaceAll("'", "&#39;");
}

function renderList(items) {
  elList.innerHTML = items.map((x, idx) => {
    const nome = escapeHtml(x.nome ?? "");
    const foto = escapeHtml(x.urlFoto ?? "");
    const total = currency.format(Number(x.totalGastos ?? 0));

    return `
      <div class="row">
        <div class="pos">#${idx + 1}</div>
        <img class="avatar" src="${foto}" alt="${nome}" loading="lazy" />
        <div class="name" title="${nome}">${nome}</div>
        <div class="value">${total}</div>
      </div>
    `;
  }).join("");
}

function renderChart(items) {
  const top = items.slice(0, 20);
  const labels = top.map(x => x.nome);
  const data = top.map(x => Number(x.totalGastos ?? 0));

  const ctx = document.getElementById("chart");
  if (chart) chart.destroy();

  chart = new Chart(ctx, {
    type: "bar",
    data: {
      labels,
      datasets: [{
        label: "Total de Gastos (R$)",
        data
      }]
    },
    options: {
      responsive: true,
      plugins: {
        legend: { display: false },
        tooltip: {
          callbacks: {
            label: (item) => currency.format(item.raw)
          }
        }
      },
      scales: {
        y: {
          ticks: {
            callback: (v) => currency.format(v)
          }
        }
      }
    }
  });
}

function applyFilter() {
  const q = (elFilter.value ?? "").trim().toLowerCase();
  const filtered = !q
    ? allItems
    : allItems.filter(x => (x.nome ?? "").toLowerCase().includes(q));

  renderList(filtered);
  renderChart(filtered);
}

async function load() {
  setStatus("Carregando...");
  elUpdatedAt.textContent = "";

  try {
    const res = await fetch("/api/deputado", { headers: { "Accept": "application/json" } });

    if (!res.ok) {
      const text = await res.text().catch(() => "");
      throw new Error(`HTTP ${res.status} - ${text || res.statusText}`);
    }

    const json = await res.json();
    allItems = Array.isArray(json) ? json : [];
    setStatus(`OK (${allItems.length})`);
    elUpdatedAt.textContent = `Atualizado em: ${new Date().toLocaleString("pt-BR")}`;

    applyFilter();
  } catch (e) {
    setStatus("Erro ao carregar");
    elList.innerHTML = `<div class="error">Falha: ${escapeHtml(e.message || String(e))}</div>`;
    if (chart) chart.destroy();
  }
}

elFilter.addEventListener("input", applyFilter);
elReload.addEventListener("click", load);

load();