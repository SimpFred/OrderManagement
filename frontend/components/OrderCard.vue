<template>
  <nuxt-link :to="{ path: `/order/${order.id}` }" class="block">
    <div
      class="bg-white shadow-md rounded-lg p-4 hover:shadow-lg hover:bg-slate-100 active:bg-slate-200 transition-bg duration-300"
    >
      <div
        class="flex flex-col md:flex-row justify-between items-start md:items-center"
      >
        <div>
          <h2 class="text-xl font-semibold mb-2">Order ID: {{ order.id }}</h2>
          <p class="text-gray-700">Kund: {{ order.customer.name }}</p>
          <p class="text-gray-500 text-sm">
            Skapad: {{ formatDate(order.createdAt) }}
          </p>
        </div>
        <div class="mt-2 md:mt-0 md:text-right">
          <p class="text-gray-700 font-semibold">
            Totalt: {{ formatPrice(order.totalCost) }} SEK
          </p>
        </div>
      </div>
    </div>
  </nuxt-link>
</template>

<script setup lang="ts">
import { defineProps } from "vue";
import type { Order } from "~/types";

defineProps<{ order: Order }>();
</script>
